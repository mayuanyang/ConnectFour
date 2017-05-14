using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConnectFour.Core.Interfaces;

namespace ConnectFour.Core
{
    public class InMemoryGameRepo : IGameRepo
    {
        private List<Game> _games;
        public InMemoryGameRepo()
        {
            _games = new List<Game>();
        }
        public Task Save(Game game)
        {
            _games.Add(game);
            return Task.CompletedTask;
        }

        public Task<Game> GetById(Guid id)
        {
            return Task.FromResult(_games.Single<Game>(x => x.Id == id));
        }

        public async Task Remove(Guid id)
        {
            var game = await GetById(id);
            _games.Remove(game);
        }
    }
}