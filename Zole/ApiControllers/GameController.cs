using App.Zole.Exceptions;
using App.Zole.Helpers;
using App.Zole.Models;
using App.Zole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using App.Zole.ApiModels;
using AutoMapper;

namespace App.Zole.ApiControllers
{
    public class GameController : ApiController
    {
        // /api/Game/Games
        public IEnumerable<ApiGame> GetGames()
        {
            var repository = new GameRepository();
            List<Game> games = repository.GetGames();

            if (games.Count == 0)
            {
                CreateTestData(repository);
            }

            return Mapper.Map<List<ApiGame>>(games);
        }

        private void CreateTestData(GameRepository repository)
        {
            var game = new Game(GameStatus.Gathering);
            repository.Create(game);

            game = new Game(GameStatus.Playing);
            repository.Create(game);
            //var user1 = new User { Name = "chick" };
            //var user2 = new User { Name = "boom" };
            //var user3 = new User { Name = "raw" };
            //return new List<Game>{
            //    new Game{
            //        Id=1,
            //        Status=GameStatus.Completed,
            //        Players=new List<User>{user1, user2, user3}
            //    },
            //    new Game{
            //        Id=2,
            //        Status=GameStatus.Gathering,
            //        Players=new List<User>{user3}
            //    },
            //    new Game{
            //        Id=3,
            //        Status=GameStatus.Playing,
            //        Players=new List<User>{user3, user2, user1}
            //    }
            //};
        }

        [AcceptVerbs("PUT")]
        public void PutJoinGame(GameIdParam parameter)
        {
            Check.NotNull(parameter, "parameter");
            Check.NotNull(parameter.gameId, "parameter.gameId");

            string user = GetUser();

            var repository = new GameRepository();
            Game game = repository.GetGame(parameter.gameId);
            int index = 0;
            //game.Players = game.Players ?? new Player[3];
            while (index < game.Players.Length && game.Players[index] != null)
            {
                if (string.Equals(user, game.Players[index].UserName, StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidStateException();
                }
            }

            if (index == game.Players.Length)
            {
                throw new InvalidStateException();
            }

            game.Players[index] = new Player(user, PlayerRole.Unknown);
            repository.Save(game);
        }

        private string GetUser()
        {
            string cookieName = "u";
            CookieHeaderValue cookie = Request.Headers.GetCookies(cookieName).FirstOrDefault();
            Check.NotNull(cookie, "userName");
            string userName = cookie[cookieName].Value;
            Check.NotNullOrEmpty(userName, "userName");
            return userName;
        }
    }
}