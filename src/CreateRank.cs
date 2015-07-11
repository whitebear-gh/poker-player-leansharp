using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        public static dynamic CreateRank(JObject gameState)
        {
            if (gameState.round == 0)
            {
                return FirstRound(gameState);
            }
            return null;
        }

        private static int FirstRound(JObject gameState)
        {
            var firstCard = gameState.hole_cards.First();
            var secondCard = gameState.hole_cards.Last();

            var numberRank = 0;
            if(int.TryParse(firstCard.rank, out numberRank))
            {
                firstCard.rank = ((NumberToString)numberRank).ToString();
            }
            if(int.TryParse(secondCard.rank, out numberRank))
            {
                secondCard.rank = ((NumberToString)numberRank).ToString();
            }
            
            var isPair = firstCard.rank == secondCard.rank;
            var areSameSuit = firstCard.suit == secondCard.suit;
            
            var rank = firstCard.rank + secondCard.rank;
            rank = isPair ? rank : (areSameSuit ? "s" : "o");

            var rankValue = 0;

            try
            {
                rankValue = (int)((StartingHandRanking) rank);
            }
            catch (Exception ex)
            {
                rank = secondCard.rank + firstCard.rank;
                rank = isPair ? rank : (areSameSuit ? "s" : "o");
                rankValue = (int)((StartingHandRanking) rank);
            }

            return rankValue;
        }
    }
}