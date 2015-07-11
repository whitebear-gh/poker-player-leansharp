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
            var cards = gameState.OurCards.Concat(gameState.CommunityCards).ToList();            
            return CheckCardsOnHand(cards);
        }
        public static Hand CheckCardsOnHand(List<RequestStructure.Card> cards)
        {
            try
            {
                Hand flushHand = CheckCardsForFlush(cards);
                if (flushHand == Hand.StraightFlush)
                {
                    return flushHand;
                }
                var cardCounts = cards.GroupBy(card => card.Rank).Select(grouping => new { Rank = grouping.Key, Count = grouping.Count() });
                if (cardCounts.Any(arg => arg.Count == 4))
                {
                    return Hand.FourOfKind;
                }
                if (cardCounts.Any(arg => arg.Count >= 3))
                {
                    var first = cardCounts.First(arg => arg.Count >= 3);
                    var any = cardCounts.Where(arg => arg.Rank != first.Rank).Any(arg => arg.Count >= 2);
                    if (any)
                    {
                        return Hand.FullHouse;
                    }
                    if (flushHand != Hand.Nothing)
                    {
                        return flushHand;
                    }
                    return Hand.ThreeOfKind;
                }
                if (flushHand != Hand.Nothing)
                {
                    return flushHand;
                }
                var pairs = cardCounts.Where(arg => arg.Count == 2);
                if (pairs.Any())
                {
                    if (pairs.Count() > 1)
                    {
                        return Hand.TwoPair;
                    }
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