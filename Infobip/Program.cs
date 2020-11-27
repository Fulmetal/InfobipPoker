using System;
using System.Collections.Generic;
using System.Linq;

namespace Infobip
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int playerCount = 4;
                int cardsDealt = 5;

                List<PlayerHand> players = new List<PlayerHand>();

                var deck = DeckBuilder.GenerateDeck();

                //sanity check
                if (playerCount * cardsDealt > deck.Count()) throw new IndexOutOfRangeException("The amount of cards dealt would be larger than the deck");

                int currentCardIndex = 0;

                for (int y = 0; y < cardsDealt; y++)
                {
                    for (int x = 0; x < playerCount; x++)
                    {
                        //instance player hand for each player dependant on global variable
                        if (players.Count < playerCount)
                        {
                            PlayerHand ph = new PlayerHand();
                            ph.PlayerId = x;
                            ph.Hand = new List<Card>();
                            players.Add(ph);
                        }

                        //add cards to players hand
                        var cPlayer = players.Where(z => z.PlayerId == x).FirstOrDefault();
                        cPlayer.Hand.Add(deck[currentCardIndex]);

                        currentCardIndex++;
                    }
                }

                //display players hands in the console
                foreach (PlayerHand ph in players)
                {
                    Console.WriteLine("Player " + ph.PlayerId);

                    foreach (Card c in ph.Hand)
                    {
                        Console.WriteLine(CardHelpers.ValueConvert(c.Value) + " of " + c.Suit);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
           

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
