using System;
using ConnectFour.Core.Interfaces;
using ConnectFour.Core;
using Xunit;


namespace ConnectFour.UnitTest
{
    public class GameTests
	{
		private IBoard _board;
		private Game _game;
	    private Symbol _winningSymbol;
		private bool _someOneWonEventFired;
		private bool _boardFullEventFired;
        private Guid _id = Guid.NewGuid();

		public GameTests()
		{
		    _someOneWonEventFired = false;
		    _boardFullEventFired = false;

            var builder = new GameBuilder();
		    _game = builder
		        .WithBoard(new Board(7,6, () =>
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

		}

		[Fact]
		public void ConnectEventShouldNotFireForPartialFillBoard()
		{
			
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));

			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.Y));

			
			Assert.False(_someOneWonEventFired);
			Assert.False(_boardFullEventFired);

		}

		[Fact]
		public void YellowWinsHorizontal()
		{
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(1, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.Y));

			Assert.True(_someOneWonEventFired);
		    Assert.True(_winningSymbol == Symbol.Y);
            Assert.False(_boardFullEventFired);

		}


	    [Fact]
	    public void YellowWinsInHorizontalFullBoard()
	    {
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.R));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));

	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.Y));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.Y));

	        _board.PutCounterAt(2, new Counter(Symbol.Y));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.Y));
	        _board.PutCounterAt(2, new Counter(Symbol.Y));

	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.R));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.R));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));

	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.Y));
	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.Y));
	        _board.PutCounterAt(4, new Counter(Symbol.R));

	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.Y));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.Y));

	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.Y));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.Y));
	        Assert.True(_someOneWonEventFired);
	        Assert.True(_winningSymbol == Symbol.Y);
	        Assert.True(_boardFullEventFired);

	    }

        [Fact]
	    public void YellowWinsVertical()
	    {
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));

            Assert.True(_someOneWonEventFired);
            Assert.True(_winningSymbol == Symbol.Y);
	        Assert.False(_boardFullEventFired);

	    }

	    [Fact]
	    public void YellowWinsVerticalFullBoard()
	    {
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.Y));
	        _board.PutCounterAt(0, new Counter(Symbol.R));

	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.Y));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.R));
	        _board.PutCounterAt(1, new Counter(Symbol.Y));

	        _board.PutCounterAt(2, new Counter(Symbol.Y));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.R));
	        _board.PutCounterAt(2, new Counter(Symbol.Y));
	        _board.PutCounterAt(2, new Counter(Symbol.Y));

	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.R));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.Y));
	        _board.PutCounterAt(3, new Counter(Symbol.R));

	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.Y));
	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.R));
	        _board.PutCounterAt(4, new Counter(Symbol.Y));
	        _board.PutCounterAt(4, new Counter(Symbol.R));

	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.Y));
	        _board.PutCounterAt(5, new Counter(Symbol.R));
	        _board.PutCounterAt(5, new Counter(Symbol.Y));

	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.Y));
	        _board.PutCounterAt(6, new Counter(Symbol.R));
	        _board.PutCounterAt(6, new Counter(Symbol.Y));
	        Assert.True(_someOneWonEventFired);

	        Assert.True(_boardFullEventFired);

	    }

        [Fact]
		public void YellowWinsInDiagonalHighToLow()
		{
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.Y));

			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.Y));

			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.Y));

			_board.PutCounterAt(3, new Counter(Symbol.Y));

			Assert.True(_someOneWonEventFired);
		    Assert.True(_winningSymbol == Symbol.Y);
            Assert.False(_boardFullEventFired);

		}

		[Fact]
		public void YellowWinsInDiagonalLowToHigh()
		{
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));

			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.Y));

			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.Y));

			_board.PutCounterAt(3, new Counter(Symbol.Y));

			Assert.True(_someOneWonEventFired);
		    Assert.True(_winningSymbol == Symbol.Y);
            Assert.False(_boardFullEventFired);

		}

		[Fact]
		public void YellowWinsInDiagonalHighToLowFullBoard()
		{
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.R));

			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.Y));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.Y));

			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.Y));

			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.R));
			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.R));

			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.Y));
			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.Y));
			_board.PutCounterAt(4, new Counter(Symbol.R));

			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.Y));

			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));
			Assert.True(_someOneWonEventFired);
		    Assert.True(_winningSymbol == Symbol.Y);
            Assert.True(_boardFullEventFired);

		}

		


		[Fact]
		public void NobodyWinsInFullBoard()
		{
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));

			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.Y));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));
			_board.PutCounterAt(1, new Counter(Symbol.R));

			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.R));
			_board.PutCounterAt(2, new Counter(Symbol.Y));
			_board.PutCounterAt(2, new Counter(Symbol.Y));

			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.R));
			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.Y));
			_board.PutCounterAt(3, new Counter(Symbol.R));
			_board.PutCounterAt(3, new Counter(Symbol.Y));

			_board.PutCounterAt(4, new Counter(Symbol.Y));
			_board.PutCounterAt(4, new Counter(Symbol.Y));
			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.R));
			_board.PutCounterAt(4, new Counter(Symbol.Y));
			_board.PutCounterAt(4, new Counter(Symbol.R));

			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.Y));
			_board.PutCounterAt(5, new Counter(Symbol.R));
			_board.PutCounterAt(5, new Counter(Symbol.Y));

			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));
			_board.PutCounterAt(6, new Counter(Symbol.R));
			_board.PutCounterAt(6, new Counter(Symbol.Y));
			Assert.False(_someOneWonEventFired);

			Assert.True(_boardFullEventFired);

		}
	}
}
