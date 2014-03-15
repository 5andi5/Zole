using App.Zole.Exceptions;
using App.Zole.Models.GameStates;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models
{
    public class Game
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement]
        public GameStatus Status { get; private set; }

        [BsonElement]
        public Player[] Players { get; private set; }

        [BsonElement]
        public int ActivePlayerIndex { get; set; }

        [BsonElement]
        public Card[] Cards { get; private set; }

        [BsonIgnore]
        public GameActionsBase Actions
        {
            get
            {
                return GameActionsFactory.Create(this);
            }
        }

        [BsonConstructor]
        public Game(ObjectId id, GameStatus status, Player[] players, int activePlayerIndex, Card[] cards)
        {
            this.Id = id;
            this.Status = status;
            this.Players = players;
            this.ActivePlayerIndex = activePlayerIndex;
            this.Cards = cards;
        }

        //public Game(GameStatus status)
        //{
        //    this.Status = status;
        //    this.Players = new Player[3];
        //    this.ActivePlayerIndex = 0;
        //}

        public Game(string userName)
        {
            this.Status = GameStatus.Gathering;
            this.Players = new Player[3];
            this.Players[0] = new Player(userName, PlayerRole.Unknown);
            this.ActivePlayerIndex = 0;
            this.Cards = CardFactory.CreateAll();
        }

        internal Player AsActivePlayer(User user)
        {
            Player player = this.Players[this.ActivePlayerIndex];
            if (player.UserName != user.UserName)
            {
                throw new AccessDeniedException();
            }
            return player;
        }

        internal void ChangeStatus(GameStatus gameStatus)
        {
            this.Status = gameStatus;
        }

        internal void ActivateNextPlayer()
        {
            this.ActivePlayerIndex = (this.ActivePlayerIndex + 1) % 3;
        }

        internal void ActivatePlayer(int playerIndex)
        {
            if (0 <= playerIndex && playerIndex <= 2)
            {
                this.ActivePlayerIndex = playerIndex;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}