using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.Models
{
    public static class CardFactory
    {
        public static Card[] CreateAll()
        {
            return new Card[]{
                new Card("D7"),
                new Card("D8"),
                new Card("D9"),
                new Card("D10"),
                new Card("DA"),
                new Card("DJ"),
                new Card("DQ"),
                new Card("DK"),

                new Card("H9"),
                new Card("H10"),
                new Card("HA"),
                new Card("HJ"),
                new Card("HQ"),
                new Card("HK"),

                new Card("S9"),
                new Card("S10"),
                new Card("SA"),
                new Card("SJ"),
                new Card("SQ"),
                new Card("SK"),

                new Card("C9"),
                new Card("C10"),
                new Card("CA"),
                new Card("CJ"),
                new Card("CQ"),
                new Card("CK")
            };
        }
    }
}