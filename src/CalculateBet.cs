using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {


        public static dynamic CalculateBet(JObject gameState, dynamic rank)
        {
            int currentPot = (int)gameState["pot"];
            var maxBet = ((JArray) gameState["players"]).Max(p => (int) p["bet"]);

            return Math.Max(maxBet, currentPot);
        }
    }
}