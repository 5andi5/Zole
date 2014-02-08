using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models
{
    public class Card
    {
        public string Code { get; private set; }

        public CardOwner Owner{get; private set;}
        
        public Card(string code)
        {
            this.Code = code;
        }

        public void ChangeOwner(CardOwner owner)
        {
            //TODO: state transition checks
            this.Owner = owner;
        }
    }
}