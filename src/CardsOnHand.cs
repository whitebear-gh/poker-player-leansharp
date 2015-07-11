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
        public static dynamic CheckCardsOnHand(RequestStructure.GameState gameState)
        {
            try
            {
                var playerID = gameState.InAction;
                var cards = gameState.Players[int.Parse(playerID)].HoldCards;
                var communityCards = gameState.CommunityCards;
                var cardsOverall = cards.Concat(communityCards);

                checkIfPair(cardsOverall);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
                return Hand.Nothing;
            }

            return Hand.Nothing;
        }

        private static void checkIfPair(IEnumerable<RequestStructure.Card> cardsOverall)
        {
            throw new NotImplementedException();
        }
    }
}