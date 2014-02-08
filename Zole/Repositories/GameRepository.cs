using App.Zole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace App.Zole.Repositories
{
    public class GameRepository
    {
        public List<Game> GetGames()
        {
            return Collections.Games.FindAll().ToList();
        }

        internal void Create(Game game)
        {
            Collections.Games.Insert(game);
        }

        internal Game GetGame(string id)
        {
            return Collections.Games
                .AsQueryable<Game>()
                .First(x => x.Id == new ObjectId(id));
        }

        internal void Save(Game game)
        {
            Collections.Games.Save(game);
        }
    }
}