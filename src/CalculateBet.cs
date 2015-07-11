using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {


        public static dynamic CalculateBet(JObject gameState, dynamic rank)
        {
            var currentPot = GetCurrentPot(gameState);
            var maxBet = GetMaxBet(gameState);
            var round = GetRound(gameState);

            var actualBet = Math.Max(maxBet, currentPot);
            if (round > 10)
            {
                actualBet = actualBet*round/100;
            }
            return actualBet;
        }

        private static int GetRound(JObject gameState)
        {
            return ((int) gameState["round"]);
        }

        private static int GetCurrentPot(JObject gameState)
        {
            int currentPot = (int) gameState["pot"];
            return currentPot;
        }

        private static int GetMaxBet(JObject gameState)
        {
            var maxBet = ((JArray) gameState["players"]).Max(p => (int) p["bet"]);
            return maxBet;
        }
    }
}