using App.Zole.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models.GameStates
{
    public abstract class GameStateBase
    {
        protected Game Game { get; private set; }

        public string Code
        {
            get { return GameStateFactory.GetCode(this.GetType()); }
        }

        public GameStateBase(Game game)
        {
            this.Game = game;
        }

        public virtual GameStateBase JoinGame(Player user)
        {
            throw new InvalidStateException();
        }

        public virtual void ChooseRole(User user, PlayerRole role)
        {
            throw new InvalidStateException();
        }
    }
}