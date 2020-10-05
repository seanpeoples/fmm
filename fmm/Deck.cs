using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fmm
{
    class Deck
    {
        public enum SortTypes
        {
            Suit,
            Rank,
            Random
        }

        public override string ToString()
        {
            List<Card> cards = Cards.ToList();
            string output = "";
            foreach(Card card in cards)
            {
                output += card.ToString() + "\n";
            }
            return output;
        }

        private static Random rng = new Random();
        Queue<Card> Cards { get; set; }

        Deck()
        {
            Cards = new Queue<Card>();
        }

        public static Deck CreateDeck()
        {
            Deck deck = new Deck();

            foreach(Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    deck.AddCard(new Card(suit, rank));
                }
            }
            deck.ShuffleDeck();
            return deck;
        }

        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }

        public void ShuffleDeck()
        {
            SortBy(SortTypes.Random);
        }

        public void SortBy(SortTypes sortType, bool reverse = false)
        {
            List<Card> cardList = Cards.ToList();
            Cards.Clear();

            switch (sortType)
            {
                case SortTypes.Random:
                    while (cardList.Count > 0)
                    {
                        int r = rng.Next(cardList.Count);
                        Cards.Enqueue(cardList[r]);
                        cardList.RemoveAt(r);
                    }
                    return;
                case SortTypes.Rank:
                    cardList.Sort(delegate (Card x, Card y)
                    {
                        if (x.Rank > y.Rank) return 1;
                        else if (x.Rank < y.Rank) return -1;
                        else return 0;
                    });
                    break;
                case SortTypes.Suit:
                    cardList.Sort(delegate (Card x, Card y)
                    {
                        if (x.Suit > y.Suit) return 1;
                        else if (x.Suit < y.Suit) return -1;
                        else return 0;
                    });
                    break;
                default:
                    break;
            }
            if (reverse)
            {
                cardList.Reverse();
            }
            foreach(Card card in cardList)
            {
                Cards.Enqueue(card);
            }
            return;            
        }

        public Card DealOneCard()
        {
            if (Cards.Count > 0)
                return Cards.Dequeue();
            else
                throw new Exception("Deck is empty");
        }

        public List<Card> DealCards(int count)
        {
            List<Card> cards = new List<Card>();
            while(count > 0)
            {
                count--;
                cards.Add(DealOneCard());
            }
            return cards;
        }
    }
}
