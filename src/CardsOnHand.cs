using System;
//using System.Diagnostics.Eventing.Reader; // not available, please do not use
using System.Collections.Generic;
using System.Dynamic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        private static Dictionary<string, int> cardsQuantity = new Dictionary<string, int>();

        public static dynamic CheckCardsOnHand(RequestStructure.GameState gameState)
        {
            try
            {
                var cardsOverall = gameState.CommunityCards.Concat(gameState.OurPlayer.HoleCards).ToList();
                checkPairs(cardsOverall);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
            }

            return Hand.Nothing;
        }

        private static void checkPairs(List<RequestStructure.Card> cardsOverall)
        {
            var currentCardRank = cardsOverall[0].Rank;

            if (cardsOverall.Count > 0)
            {
                if (cardsQuantity.ContainsKey(currentCardRank))
                {
                    cardsQuantity[currentCardRank]++;
                    checkPairs(cardsOverall.GetRange(1, cardsOverall.Count-1));
                }
                else
                {
                    cardsQuantity.Add(currentCardRank, 0);
                    checkPairs(cardsOverall.GetRange(1, cardsOverall.Count - 1));
                }
            }
        }
    }
}