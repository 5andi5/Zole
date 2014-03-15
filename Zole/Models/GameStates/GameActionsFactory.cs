using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models.GameStates
{
    public class GameActionsFactory
    {
        private static Dictionary<GameStatus, Type> States =
            new Dictionary<GameStatus, Type>(StringComparer.OrdinalIgnoreCase)
        {
            {"CR", typeof(ChooseRoleActions)}
        };

        public static GameActionsBase Create(string code, Game game)
        {
            Type type = States[code];
            GameActionsBase state = (GameActionsBase)Activator.CreateInstance(type, game);
            return state;
        }

        public static string GetCode(Type stateType)
        {
            return States.Single(x => x.Value == stateType).Key;
        }
    }
}