using App.Zole.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models.GameStates
{
    public abstract class GameActionsBase
    {
        protected Game Game { get; private set; }

        public string Code
        {
            get { return GameActionsFactory.GetCode(this.GetType()); }
        }

        public GameActionsBase(Game game)
        {
            this.Game = game;
        }

        public virtual GameActionsBase JoinGame(Player user)
        {
            throw new InvalidStateException();
        }

        public virtual void ChooseRole(User user, PlayerRole role)
        {
            throw new InvalidStateException();
        }
    }
}