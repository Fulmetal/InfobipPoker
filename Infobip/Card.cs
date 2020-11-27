using System;
using System.Collections.Generic;
using System.Text;

namespace Infobip
{
    public class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }
    }

    public static class CardHelpers
    {
        //convert to user readable values
        public static string ValueConvert(int cardNumber)
        {
            switch (cardNumber)
            {
                case 1:
                    return "Ace";
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                default:
                    return cardNumber.ToString();
            }
        }
    }
}
