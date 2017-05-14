using System;
using System.Collections.Generic;

namespace ConnectFour.Core.Interfaces
{
    public interface IGame
    {
        IBoard Board { get; }
        Guid Id { get; }
        IEnumerable<Player> Players { get; }
        Action OnBoardFull { get; }
        Action<Symbol> OnConnect { get; }
    }
}