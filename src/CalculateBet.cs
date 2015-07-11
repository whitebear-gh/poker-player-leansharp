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
            var maxBetPlayer = GetMaxBetPlayer(gameState);
            var round = GetRound(gameState);

            var myStack = GetMyStack(gameState);

            var actualBet = Math.Max(maxBetPlayer.Bet, currentPot);
            if (round > 20)
            {
                actualBet = actualBet*round/100;
            }
            else if (maxBetPlayer.Bet > myStack)
            {
                actualBet = 0;
            }

            return actualBet;
        }

        private static int GetMyStack(JObject gameState)
        {
            return ((int) gameState["players"].Single(p => (string) p["name"] == "LeanSharp")["stack"]);
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

        private static dynamic GetMaxBetPlayer(JObject gameState)
        {
            var players = gameState["players"].Select(p =>
            new
            {
                Bet = p["bet"],
                Stack = p["stack"]
            });
            var topPlayer = players.OrderBy(p => p.Bet).Last();
            return topPlayer;
        }


    }
}