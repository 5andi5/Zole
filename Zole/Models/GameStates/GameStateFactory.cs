using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models.GameStates
{
    public class GameStateFactory
    {
        private static Dictionary<string, Type> States =
            new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
        {
            {"CR", typeof(ChooseRoleState)}
        };

        public static GameStateBase Create(string code, Game game)
        {
            Type type = States[code];
            GameStateBase state = (GameStateBase)Activator.CreateInstance(type, game);
            return state;
        }

        public static string GetCode(Type stateType)
        {
            return States.Single(x => x.Value == stateType).Key;
        }
    }
}