using System;
using System.Linq;
using ConnectFour.Core;
using ConnectFour.Core.Interfaces;
using Autofac;

namespace ConnectFour.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the board dimensions (number of rows, number of columns)");
            var inputs = Console.ReadLine().Split(' ');
            int numOfRows, numOfColumns;
            while (!int.TryParse(inputs[0], out numOfRows))
            {
                Console.WriteLine("number of rows must be a integer");
            }
            while (!int.TryParse(inputs[1], out numOfColumns))
            {
                Console.WriteLine("number of columns must be a integer");
            }

            bool gameFinished = false;
            var gameBuilder = new GameBuilder();
            var game = gameBuilder
                .WithBoard(new Board(4, 4, () =>
                    {
                        Console.WriteLine("Board is full");
                    },
                        x =>
                        {

                            if (x == Symbol.R)
                            {
                                Console.WriteLine("Red WINS");
                                gameFinished = true;
                            }
                            else
                            {
                                Console.WriteLine("Yellow WINS");
                                gameFinished = true;
                            }
                        }
                    ))
                .Build(Guid.NewGuid())
                ;
            var players = game.Players.ToArray();
            var printer = new ConsolePrinter();
            int index = 0;
            while (!gameFinished)
            {
                var currentPlayer = players[index % 2];
                currentPlayer.TakeTurn(game);
                printer.Print(game.Board);
                index++;
            }
            Console.ReadLine();
        }
    }
}