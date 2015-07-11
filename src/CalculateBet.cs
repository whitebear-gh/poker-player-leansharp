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

            double expectedGainChance = maxBet/currentPot;
            double positionFactor = 1 + 1/(GetActivePlayerCount(game) - GetCurrentPosition(game) + 1);
            expectedGainChance = expectedGainChance*positionFactor;

            var activePlayerCount = GetActivePlayerCount(game);

            int actualBet = 0;
            if (expectedGainChance >= (1/activePlayerCount))
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

        private static int GetMaxBet(RequestStructure.GameState game)
        {
            var maxBet = game.Players.Max(p => (int) p.Bet);
            return maxBet;
        }

        private static int GetCurrentPosition(RequestStructure.GameState game)
        {
            var activePlayerCount = GetActivePlayerCount(game);
            var dealerId = Convert.ToInt32(game.Dealer);
            if (game.OurPlayer.Id == dealerId)
            {
                return activePlayerCount;
            }
            if (game.OurPlayer.Id < dealerId)
            {
                var tmpPosition = activePlayerCount;
                for (int i = dealerId - 1; i != game.OurPlayer.Id && i > 0; i--)
                {
                    if (i == game.OurPlayer.Id) return tmpPosition;
                    if (game.Players[i].Status == RequestStructure.PlayerStatus.Active) tmpPosition -= 1;
                }
                return tmpPosition;
            }
            else
            {

                var tmpPosition = 1;
                for (int i = dealerId + 1; i < game.Players.Count; i++)
                {
                    if(i == game.OurPlayer.Id) return tmpPosition;
                    if (game.Players[i].Status == RequestStructure.PlayerStatus.Active) tmpPosition += 1;
                }
                return tmpPosition;
            }
        }
    }
}