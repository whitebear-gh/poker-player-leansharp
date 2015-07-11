using System;
//using System.Diagnostics.Eventing.Reader; // not available, please do not use
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        private static Dictionary<string, int> cardsPower = new Dictionary<string, int>();

        public static dynamic CheckCardsOnHand(RequestStructure.GameState gameState)
        {
            try
            {
                var cardsOverall = gameState.CommunityCards.Concat(gameState.OurPlayer.HoldCards).ToList();

                switch (gameState.CommunityCards.Count)
                {
                    case 3:
                        checkPairs(3, cardsOverall);
                        break;

                    case 5:
                        checkPairs(5, cardsOverall);
                        break;

                    default:
                        return Hand.Nothing;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
            }

            return Hand.Nothing;
        }

        private static void checkPairs(int cardsCount, List<RequestStructure.Card> cardsOverall)
        {
            var currentCardRank = cardsOverall[0].Rank;

            if (cardsCount > 0)
            {
                if (cardsPower.ContainsKey(currentCardRank))
                {
                    cardsPower[currentCardRank]++;
                }
                else
                {
                    cardsPower.Add(currentCardRank, Rank.GetCardValue(currentCardRank));
                }
            }
        }
    }
}