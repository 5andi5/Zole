using App.Zole.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Zole.Extensions;

namespace App.Zole.Models.GameStates
{
    public class ChooseRoleActions : GameActionsBase
    {
        public ChooseRoleActions(Game game)
            : base(game)
        { }

        public override void ChooseRole(User user, PlayerRole role)
        {
            Player currentPlayer = base.Game.AsActivePlayer(user);
            currentPlayer.ChangeRole(role);
            switch (role)
            {
                case PlayerRole.DarkGreat:
                    MakeOtherPlayersSmall(currentPlayer);
                    base.Game.Cards
                        .Where(x => x.Owner == CardOwner.TableNow)
                        .ForEach(x => x.ChangeOwner(CardOwner.SmallForever));
                    base.Game.ActivatePlayer(playerIndex: 0);
                    base.Game.ChangeStatus(GameStatus.Playing);
                    break;
                case PlayerRole.Great:
                    MakeOtherPlayersSmall(currentPlayer);
                    base.Game.ChangeStatus(GameStatus.PuttingDown);
                    break;
                case PlayerRole.Small:
                    if (base.Game.Players.Any(x => x.Role == PlayerRole.Unknown))
                    {
                        base.Game.ActivateNextPlayer();
                    }
                    else
                    {
                        base.Game.ActivatePlayer(playerIndex: 0);
                        base.Game.ChangeStatus(GameStatus.PlayingTable);
                    }
                    break;
                case PlayerRole.Table:
                case PlayerRole.Unknown:
                    throw new InvalidStateException();
                default:
                    throw new InvalidOperationException();
            }
        }

        private void MakeOtherPlayersSmall(Player currentPlayer)
        {
            base.Game.Players
                    .Where(x => x.Role == PlayerRole.Unknown)
                    .ForEach(x => x.ChangeRole(PlayerRole.Small));
        }
    }
}