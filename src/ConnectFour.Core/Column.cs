using System.Collections.Generic;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	
	public class Column : IColumn
	{
		
		public Column(int columnIndex, int columnHeight)
		{
			Index = columnIndex;
			Height = columnHeight;

			InitializeColumnSquares();
		}

		public IEnumerable<IPosition> Positions { get; private set; }
		public int Index { get; private set; }
		public int Height { get; private set; }

		private void InitializeColumnSquares()
		{
			var squares = new List<Position>();
			for (int indexInColumn = 0; indexInColumn < Height; indexInColumn++)
			{
				squares.Add(new Position(indexInColumn));
			}

			Positions = squares;
		}
	}
}