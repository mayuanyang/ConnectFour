using System;
using ConnectFour.Core;
using ConnectFour.Core.Interfaces;
using TestStack.BDDfy;
using Xunit;

namespace ConnectFour.UnitTest
{
    public class YellowWinsBddTest
    {
        private IBoard _board;
        private Game _game;
        private Symbol _winningSymbol;
        private bool _someOneWonEventFired;
        private bool _boardFullEventFired;
        private Guid _id = Guid.NewGuid();
        public void GivenYellowHas3CounterInARow()
        {
            var builder = new GameBuilder();
            _game = builder
                .WithBoard(new Board(7, 6, () =>
                    {
                        _boardFullEventFired = true;
                    },
                    x =>
                    {
                        _someOneWonEventFired = true;
                        _winningSymbol = x;

                    }
                ))
                .Build(_id);

            _board = _game.Board;
            _board.PutCounterAt(0, new Counter(Symbol.Y));
            _board.PutCounterAt(1, new Counter(Symbol.Y));
            _board.PutCounterAt(2, new Counter(Symbol.Y));
        }

        public void WhenYellowPutAnotherOneOnTheFouthColumn()
        {
            _board.PutCounterAt(3, new Counter(Symbol.Y));
        }

        public void ThenYellowShouldWin()
        {
            Assert.True(_someOneWonEventFired);
            Assert.Equal(Symbol.Y, _winningSymbol);

        }

        [Fact]
        public void Run()
        {
            this.BDDfy();
        }
    }
}
