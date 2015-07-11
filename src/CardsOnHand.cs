using System;
using System.Dynamic;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        public static Hand CheckCardsOnHand(JObject gameState)
        {
            try
            {
                return Hand.Nothing;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
                return Hand.Nothing;
            }
        }
    }

    public class Card
    {
        public char rank;
        public string suit;
    }
}