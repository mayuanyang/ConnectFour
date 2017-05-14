using System;
using System.Collections.Generic;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{

    public class Game : IGame
    {
        public Guid Id { get; }
        public IBoard Board { get; }
        public IEnumerable<Player> Players { get; internal set; }
        public Action OnBoardFull { get;  }
        public Action<Symbol> OnConnect { get; }

        public Game(Guid id, int width, int height, Action onBoardFull, Action<Symbol> onConnect, IBoard board)
        {
            Id = id;
            OnBoardFull = onBoardFull;
            OnConnect = onConnect;
            Board = board;
        }
    }
}