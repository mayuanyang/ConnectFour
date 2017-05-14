using System.Linq;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(IBoard board)
        {
            System.Console.WriteLine();
            ICounter counter;
            for (int rowIndex = board.Height - 1; rowIndex >= 0; rowIndex--)
            {
                foreach (var gridColumn in board.Columns)
                {
                    counter = gridColumn.Positions.ElementAt(rowIndex).Counter;
                    System.Console.Write(counter != null ? counter.Symbol.ToString() : "0");
                    System.Console.Write(" ");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }
    }
}