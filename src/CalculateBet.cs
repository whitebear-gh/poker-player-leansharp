using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {


        public static dynamic CalculateBet(JObject gameState, dynamic rank)
        {
            var game = new RequestStructure.GameState(gameState);

            var allInPlayersCount = GetAllInPlayersCount(game);

            if(allInPlayersCount == 1)
            {
                return GetMaxBet(game);
            }
            if(allInPlayersCount > 2)
            {
                return 0;
            }


            var currentPot = Convert.ToInt32(game.Pot);
            var maxBet = GetMaxBet(game);

            // ReSharper disable once PossibleLossOfFraction
            double effective = maxBet/(currentPot/2);

            var activePlayerCount = GetActivePlayerCount(game);

            int actualBet = 0;
            // ReSharper disable once PossibleLossOfFraction
            if (effective >= (1/activePlayerCount))
            {
                var round = GetRound(gameState);

                actualBet = new[] {maxBet, currentPot}.Max(s => s);
                if (round > 10)
                {
                    actualBet = actualBet*(round/10);
                }
                else
                {
                    actualBet = actualBet*(round/100);
                }
            }
            return actualBet;
        }

        private static int GetActivePlayerCount(RequestStructure.GameState game)
        {
            return game.Players.Count(p => p.Status == RequestStructure.PlayerStatus.Active);
        }

        private static int GetAllInPlayersCount(RequestStructure.GameState game)
        {
            return game.Players.Count(p => p.Stack == p.Bet);
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

        private static int GetMaxBet(RequestStructure.GameState game)
        {
            var maxBet = game.Players.Max(p => (int) p.Bet);
            return maxBet;
        }
    }
}