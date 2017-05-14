using System;
using System.Collections.Generic;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
	public class GameBuilder
	{
	    private int _boardWidth;
	    private int _boardHeight;
	    private Action<Symbol> _onSomeoneWon;
	    private Action _onBoardFull;
	    private IBoard _board;

        
	    public GameBuilder WithBoard(IBoard board)
	    {
	        _board = board;
	        return this;
	    }

	    
        public Game Build(Guid id)
		{
		    return new Game(id, _boardWidth, _boardHeight, _onBoardFull, _onSomeoneWon, _board)
		    {
		        Players = new List<Player>()
		        {
		            new Player(Symbol.R),
		            new Player(Symbol.Y)
		        }
		    };
		}
	}
}