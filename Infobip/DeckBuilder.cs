using System;
using System.Collections.Generic;
using System.Text;

namespace Infobip
{
    public static class DeckBuilder
    {
        private static Random rng = new Random();

        //returned to previous generic
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }


        public static List<Card> GenerateDeck()
        {
          List<Card> list = new List<Card>();

            List<string> suits = new List<string>()
            {
                "Hearts",
                "Diamonds",
                "Spades",
                "Clubs"
            };

            foreach (string s in suits)
            {
                for (int i = 1; i < 14; i++)
                {
                    Card c = new Card();

                    c.Suit = s;
                    c.Value = i;

                    list.Add(c);
                }
            }

            //why was this so confusing yesterday??!!?? :D
            list.Shuffle();

            return list;
        }
    
    }
}
