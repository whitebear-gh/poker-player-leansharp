using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {

        public static int? CreateRank(RequestStructure.GameState gameState,Hand hand)
        {
            var isFirstRound = !gameState.CommunityCards.Any();

            if (isFirstRound)
            {
                return FirstRound(gameState);
            }

                return (int)hand;
            

            
            return null;
        }

        private static int FirstRound(RequestStructure.GameState gameState)
        {
            var cards = gameState.OurPlayer.HoleCards;

            var firstCard = cards.First();
            var secondCard = cards.Last();

            var firstCardRank = firstCard.Rank;
            var secondCardRank = secondCard.Rank;

            var firstCardSuit = firstCard.Suit;
            var secondCardSuit = secondCard.Suit;

            var numberRank = 0;
            if (int.TryParse(firstCardRank, out numberRank))
            {
                firstCardRank = ((NumberToString)numberRank).ToString();
            }
            if (int.TryParse(secondCardRank, out numberRank))
            {
                secondCardRank = ((NumberToString)numberRank).ToString();
            }

            var isPair = firstCardRank == secondCardRank;
            var areSameSuit = firstCardSuit == secondCardSuit;

            var rank = firstCardRank + secondCardRank;
            rank = isPair ? rank : rank + (areSameSuit ? "s" : "o");

            var rankValue = 0;

            try
            {
                rankValue = (int)Enum.Parse(typeof(StartingHandRanking), rank);
            }
            catch (Exception ex)
            {
                rank = secondCardRank + firstCardRank;
                rank = isPair ? rank : rank + (areSameSuit ? "s" : "o");
                rankValue = (int)Enum.Parse(typeof(StartingHandRanking), rank);
            }

            return rankValue;
        }
    }
}