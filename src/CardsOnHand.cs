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
                if (IsFourOfKind(cards))
                    return Hand.FourOfKind;
                if (IsFullHouse(cards))
                    return Hand.FullHouse;
                if (IsPair(cards))
                {
                    return Hand.Pair;
                }
                return Hand.Nothing;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
            }

                return Hand.Nothing;
            }
        

        public static bool  IsPair(List<RequestStructure.Card> cards)
        {
            return false;
        }


        public static List<int> GetCounts(List<RequestStructure.Card> cardsOverall)
        {
            return cardsOverall.GroupBy(x => x.Rank).Select(x => x.Count()).OrderBy(x => x).ToList();
        }

        public static bool IsFullHouse(List<RequestStructure.Card> cardsOverall)
        {
            var counts = GetCounts(cardsOverall);

            var atLeastTwo = counts.Where(x => x >= 2);
            var atLeastThree = counts.Where(x => x >= 2);

            return atLeastTwo.Count() >= 2 && atLeastThree.Count() >= 1;
        }

        public static bool IsFourOfKind(List<RequestStructure.Card> cardsOverall)
        {
            var counts = GetCounts(cardsOverall);

            return counts.Any(x => x >= 4);
        }
        
    }
}