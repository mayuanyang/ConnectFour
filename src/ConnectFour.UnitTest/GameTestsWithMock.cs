using System;
using ConnectFour.Core.Interfaces;
using ConnectFour.Core;
using NSubstitute;
using Xunit;


namespace ConnectFour.UnitTest
{
    public class GameTestsWithMock
    {
		private IBoard _board;
		private IGame _game;
	    private Symbol _winningSymbol;
		private bool _someOneWonEventFired;
		private bool _boardFullEventFired;
        private Guid _id = Guid.NewGuid();

		public GameTestsWithMock()
		{
		    _someOneWonEventFired = false;
		    _boardFullEventFired = false;
		    _board = NSubstitute.Substitute.For<IBoard>();

            var builder = new GameBuilder();
		    _game = builder
		        .WithBoard(_board)
		        .Build(_id);

		}

		[Fact]
		public void MethodsShouldReceivedRightNumberOfCalls()
		{
			
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));

			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.Y));

		    _board.Received(6).PutCounterAt(Arg.Any<int>(), Arg.Any<ICounter>());

		}

		
	}
}
