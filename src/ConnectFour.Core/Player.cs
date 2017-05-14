using System;
using System.Linq;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	
	public class Player
	{
		
		public Player(Symbol symbol)
		{
			Symbol = symbol;
		}

		public Symbol Symbol { get; private set; }
		
		
		public void TakeTurn(Game game)
		{
		    Console.WriteLine(this.Symbol == Symbol.R ? "Reds turn:" : "Yellows turn:");

		    bool turnTaken = false;
			
			while (!turnTaken)
			{
			    var columnNumberString = Console.ReadLine();
	
				if (!int.TryParse(columnNumberString, out int columnNumber))
				{
				    Console.WriteLine("Please try again. Input must be a number representing the column number i.e. 1, 2, 3, etc");
					continue;
				}
				if (columnNumber < 1 || columnNumber > game.Board.Columns.Count())
				{
				    Console.WriteLine($"Please try again. There is no column with that number. Input must be between 1 and {game.Board.Columns.Count()}");
					continue;
				}

				var columnIndex = columnNumber - 1;
				
				if (!game.Board.CanPutCounterAt(columnIndex))
				{
				    Console.WriteLine("That column is full please try again");
					continue;
				}
				try
				{
					game.Board.PutCounterAt(columnIndex, new Counter(Symbol));
					turnTaken = true;
				}
				catch (Exception ex)
				{
				    Console.WriteLine($"Invalid move - {ex.Message}");
				}
			}
		}
	}
}