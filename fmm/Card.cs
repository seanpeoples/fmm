using System;
using System.Collections.Generic;
using System.Text;

namespace fmm
{
    class Card
    {
        public Rank Rank { get; set; }
        public int Value { get; set; }
        public Suit Suit { get; set; }

        public Card(Suit suit, Rank rank, int? value = null)
        {
            this.Suit = suit;
            this.Rank = rank;
            this.Value = value != null ? value.Value : (int)Rank;
        }

        public override string ToString()
        {
            return Suit.ToString() + '-' + Rank.ToString();
        }
    }
}
