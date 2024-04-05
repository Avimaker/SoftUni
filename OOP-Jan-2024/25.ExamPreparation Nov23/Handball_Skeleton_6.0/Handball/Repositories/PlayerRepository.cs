using System.Collections.Generic;
using System.Linq;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            players.Add(model);
        }

        //тук връща true or flase (any)
        public bool ExistsModel(string name)
        {
            return players.Any(p => p.Name == name);
        }

        //тук връща playera или null (FirstOrDefault)
        public IPlayer GetModel(string name)
        {
            return players.FirstOrDefault(p => p.Name == name);
        }

        //public bool RemoveModel(string name)
        //{
        //    IPlayer playerToRemove = players.FirstOrDefault(p => p.Name == name);
        //    if (playerToRemove != null)
        //    {
        //        players.Remove(playerToRemove);
        //        return true;
        //    }
        //    return false;
        //}
        public bool RemoveModel(string name) => this.players.Remove(this.players.FirstOrDefault(p => p.Name == name));
    }
}

