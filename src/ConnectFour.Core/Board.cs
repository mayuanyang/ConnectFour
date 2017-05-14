using System;
using System.Collections.Generic;
using System.Linq;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	public class Board : IBoard
    {
        private readonly Action _onBoardFull;
        private readonly Action<Symbol> _onSomeoneWins;

        private const int WinningConnectCount = 4;
		public Board(int width, int height, Action onBoardFull, Action<Symbol> onSomeoneWins)
		{
		    _onBoardFull = onBoardFull;
		    _onSomeoneWins = onSomeoneWins;
		    Height = height;
			Width = width;
			Initialize();
			
		}

		public IEnumerable<IColumn> Columns { get; private set; }
		public int Height { get; private set; }
		public int Width { get; private set; }
	    
		private List<Tuple<int, Symbol>> Moves { get; set; } 

		public bool CanPutCounterAt(int columnIndex)
		{
			if (columnIndex < 0 || columnIndex >= Columns.Count())
				throw new ArgumentOutOfRangeException(string.Format("columnindex must be between 0 and {0} and was {1}", Columns.Count() - 1, columnIndex));

			var column = Columns.ElementAt(columnIndex);

			return column.Positions.Any(pos => pos.Counter == null);
		}

		public void PutCounterAt(int columnIndex, ICounter counter)
		{
			if (columnIndex < 0 || columnIndex >= Columns.Count())
				throw new ArgumentOutOfRangeException(string.Format("columnindex must be between 0 and {0} and was {1}", Columns.Count() - 1, columnIndex));

			if(!CanPutCounterAt(columnIndex))
				throw new InvalidOperationException(string.Format("Column {0} is full", columnIndex));

			var column = Columns.ElementAt(columnIndex);

			//Get the gridsquare that the counter will fall to.
			//This will be the gridsquare with the minimum index that doesnt have a counter
			var lowestEmptyColumnSquare = column.Positions
											.First(columnSquare => columnSquare.Counter == null);

			lowestEmptyColumnSquare.SetCounter(counter);

			//Track move
			Moves.Add(new Tuple<int, Symbol>(columnIndex, counter.Symbol));

			if(HasConnectBeenDetected())
			{
			    _onSomeoneWins?.Invoke( counter.Symbol);
			}

			if(IsFull())
			{
			    _onBoardFull?.Invoke();
			}
		}

		private bool IsFull()
		{
			return !Columns.Any(column => CanPutCounterAt(column.Index));
		}


		private bool HasConnectBeenDetected()
		{
			return CheckRows()
				   || CheckColumns()
				   || CheckDiagonalRows();
		}

		internal bool CheckDiagonalRows()
		{
            var allPositions = Columns.Select(column => column.Positions.ToArray()).ToArray();

            for (int diagColumnStart = 0; diagColumnStart < Width; diagColumnStart++)
			{
				for (int diagRowStart = Height - 1; diagRowStart >= 0; diagRowStart--)
				{
					var positionsToCheck = new List<IPosition>();
					for (int rowIndex = diagRowStart, columnIndex = diagColumnStart; rowIndex >= 0 && columnIndex < Width; rowIndex--, columnIndex++)
					{
						positionsToCheck.Add(allPositions[columnIndex][rowIndex]);
					}

					if (HasConnection(positionsToCheck))
						return true;
				}
			}

			var theReversedBoard = allPositions.Reverse().ToArray();

			for (int diagColumnStart = 0; diagColumnStart < Width; diagColumnStart++)
			{
				for (int diagRowStart = Height - 1; diagRowStart >= 0; diagRowStart--)
				{
					var positionsToCheck = new List<IPosition>();
					for (int rowIndex = diagRowStart, columnIndex = diagColumnStart; rowIndex >= 0 && columnIndex < Width; rowIndex--, columnIndex++)
					{
						positionsToCheck.Add(theReversedBoard[columnIndex][rowIndex]);
					}

					if (HasConnection(positionsToCheck))
						return true;
				}
			}
			return false;
		}

		internal bool CheckRows()
		{
            var allPositions = Columns.Select(column => column.Positions.ToArray()).ToArray();
            for (int rowIndex = 0; rowIndex < Height; rowIndex++)
			{
				var squaresToCheck = new List<IPosition>();
				for (int columnIndex = 0; columnIndex < Width; columnIndex++)
				{
					squaresToCheck.Add(allPositions[columnIndex][rowIndex]);
				}
				if (HasConnection(squaresToCheck))
					return true;
			}
			return false;
		}

		internal bool CheckColumns()
		{
		    var allPositions = Columns.Select(column => column.Positions.ToArray()).ToArray();
            for (int columnIndex = 0; columnIndex < Width; columnIndex++)
			{
				var squaresToCheck = new List<IPosition>();
				for (int rowIndex = 0; rowIndex < Height; rowIndex++)
				{
					squaresToCheck.Add(allPositions[columnIndex][rowIndex]);
				}
				if (HasConnection(squaresToCheck))
					return true;
			}
			return false;
		} 

		private bool HasConnection(IEnumerable<IPosition> positionsToCheck)
		{
			if (positionsToCheck == null)
				throw new ArgumentException($"{nameof(positionsToCheck)} cannot be null");

			var positionsWithCounters = positionsToCheck.Where(pos => pos.Counter != null);

			if (positionsWithCounters.Count() < WinningConnectCount)
				return false;

			int colourCount = 0;
			Symbol initialColour = positionsWithCounters.First().Counter.Symbol;

			foreach (var pos in positionsWithCounters)
			{
				if (pos.Counter == null)
					continue;
				if (pos.Counter.Symbol == initialColour)
				{
					colourCount++;
				}
				else
				{
					initialColour = pos.Counter.Symbol;
					colourCount = 1;
				}

				if (colourCount == WinningConnectCount)
				{
					return true;
				}
			}

			return false;
		}


		private void Initialize()
		{
			var columns = new List<Column>();
			for (int columnIndex = 0; columnIndex < Width; columnIndex++)
			{
				columns.Add(new Column(columnIndex, Height));
			}

			Columns = columns;
		    Moves = new List<Tuple<int, Symbol>>();
        }


		internal void ClearGrid()
		{
			Initialize(); 
		}
	}
}
