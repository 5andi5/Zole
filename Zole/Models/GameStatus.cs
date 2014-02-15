using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models
{
    public enum GameStatus
    {
        Gathering = 0,
        ChooseRole = 1,
        PuttingDown = 2,
        Playing = 3,
        PlayingTable = 4,
        Completed = 5
    }
}