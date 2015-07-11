using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        public static Hand CheckCardsOnHand(RequestStructure.GameState gameState)
        {
            try
            {
                var cards = gameState.OurCards.Concat(gameState.CommunityCards).ToList();
                if (IsPair(cards))
                {
                    return Hand.Pair;
                }
                return Hand.Nothing;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
                return Hand.Nothing;
            }
        }

        public static bool  IsPair(List<RequestStructure.Card> cards)
        {
            return false;
        }
    }

    public class Card
    {
        public char rank;
        public string suit;
    }
}