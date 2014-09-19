﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerPlayer
{
    //enumerator for number on card
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    //enumerator for suit of card
    public enum Suit
    {
        Spades = 1,
        Clubs,
        Diamonds,
        Hearts
    }
    class Card
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank r, Suit s)
        {
            this.Rank = r;
            this.Suit = s;
        }

        public string GetCardString()
        {
            return this.Rank + " of " + this.Suit;
        }
    }
}
