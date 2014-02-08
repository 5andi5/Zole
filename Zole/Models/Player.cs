using App.Zole.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models
{
    public class Player
    {
        public string UserName { get; private set; }
        public PlayerRole Role { get; private set; }

        public Player(string userName, PlayerRole role)
        {
            this.UserName = userName;
            this.Role = role;
        }

        public void ChangeRole(PlayerRole newRole)
        {
            if (this.Role != PlayerRole.Unknown)
            {
                throw new InvalidStateException();
            }
            this.Role = newRole;
        }
    }
}