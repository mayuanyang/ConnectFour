using ConnectFour.Core.Interfaces;
using ConnectFour.Core;
using Xunit;
using System.Linq;
using System;


namespace ConnectFour.UnitTest
{
	
    public class BoardTests
    {
		private IBoard _board;
        private Guid _id = Guid.NewGuid();

		
		public BoardTests()
		{
		    _board = new Board(7, 6, null, null);

		}

		
		[Fact]
		public void EachColumnHas6Positions()
		{
			foreach(var column in _board.Columns)
			{
				Assert.True(column.Positions.Count() == 6);
			}
		}

		[Fact]
		public void PutIncorrectColumnIndexShouldThrowArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _board.PutCounterAt(-1, new Counter(Symbol.Y)));
		}

		[Fact]
		public void PutToIndexOutsideOfBoardShouldThrowArgumentOutOfRangeException()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _board.PutCounterAt(7, new Counter(Symbol.Y)));
		}

		[Fact]
		public void PutCounterToFullBoardShouldThrowInvalidOperationException()
		{
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.Y));
			_board.PutCounterAt(0, new Counter(Symbol.R));
			Assert.Throws<InvalidOperationException>(() => _board.PutCounterAt(0, new Counter(Symbol.Y)));
		}

		
    }
}
