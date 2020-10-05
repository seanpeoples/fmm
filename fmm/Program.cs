using System;
using System.Collections.Generic;

namespace fmm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Deck
            Console.WriteLine("Create Deck");
            Deck deck = Deck.CreateDeck();
            Console.WriteLine(deck.ToString());

            //Deal 5 cards
            Console.WriteLine("Deal 5 Cards");
            List<Card> cards = deck.DealCards(5);
            foreach(Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }

            //Order Deck By Rank
            Console.WriteLine("\nOrder By Rank");
            deck.SortBy(Deck.SortTypes.Rank);
            Console.WriteLine(deck.ToString());

            //Deal 10 cards
            Console.WriteLine("Deal 10 Cards");
            cards = deck.DealCards(10);
            foreach (Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }

            //Order Deck By Suit
            Console.WriteLine("\nOrder By Suit");
            deck.SortBy(Deck.SortTypes.Suit);
            Console.WriteLine(deck.ToString());

            //Deal 10 cards
            Console.WriteLine("Deal 10 Cards");
            cards = deck.DealCards(10);
            foreach (Card card in cards)
            {
                Console.WriteLine(card.ToString());
            }

            //Shuffle deck
            Console.WriteLine("\nShuffle Deck");
            deck.SortBy(Deck.SortTypes.Random);
            Console.WriteLine(deck.ToString());

            //Deal 1 card
            Console.WriteLine("Deal 1 Card");
            Console.WriteLine(deck.DealOneCard().ToString());

            //Wait
            Console.ReadLine();
        }
    }
}
