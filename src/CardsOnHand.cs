using System;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        public static dynamic CheckCardsOnHand(JObject gameState)
        {
            try
            {
                return Hand.Nothing;
                //var des = (Card) Newtonsoft.Json.JsonConvert.DeserializeObject(response, typeof (Card));

            }
            catch (Exception e)
            {
                Console.WriteLine("Error during card checking in hands:\n"+e.Message);
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