using System;
using System.Threading.Tasks;

namespace ConnectFour.Core.Interfaces
{
    public interface IGameRepo
    {
        Task Save(Game game);
        Task<Game> GetById(Guid id);
        Task Remove(Guid id);
    }
}
