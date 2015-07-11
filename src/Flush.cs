using System;
using System.Collections.Generic;
using System.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
         public static Hand CheckCardsForFlush(List<RequestStructure.Card> cards)
         {
            try
            {
                if (cards.Count() < 5)
                {
                    return Hand.Nothing;
                }
                return CheckFlush(cards);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
            }

            return Hand.Nothing;
         }

        private static Hand CheckFlush(List<RequestStructure.Card> cards)
        {
            var numberRank = 0;
            CardInt[] cardRanks = cards.Select(x => new CardInt { Suit = x.Suit, Rank = 0 }).ToArray();
            for (int i = 0; i < cards.Count(); i++)
            {
                string cardRank = null;
                if (int.TryParse(cards[i].Rank, out numberRank))
                {
                    cardRank = ((NumberToString)numberRank).ToString();
                }
                else
                {
                    cardRank = cards[i].Rank;
                }
                cardRanks[i].Rank = (int)Enum.Parse(typeof(CardValue), cardRank);
            }

            cardRanks = cardRanks.OrderBy(x => x.Rank).ToArray();
            bool flush = false;
            bool straight = false;

            for (int i = 0; i <= cardRanks.Count()-5; i++)
            {
                straight = CheckForStraight(cardRanks.Skip(i).Take(5).ToArray());
                flush = IsSameColour(cardRanks);
                if (straight && flush)
                {
                    return Hand.StraightFlush;
                }
                else if (flush)
                {
                    return Hand.Flush;
                }
                else if (straight)
                {
                    return Hand.Straight;
                }
            }

            if (IsSameColour(cardRanks))
            {
                return Hand.Flush;
            }
            return Hand.Nothing;
        }

        private class CardInt 
        {
            public int Rank;
            public RequestStructure.Suit Suit;
        }

        private static bool CheckForStraight(CardInt[] cards)
        {
            for (int i = 1; i < cards.Count(); i++)
            {
                if (cards[i].Rank - cards[i - 1].Rank > 1)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsSameColour(CardInt[] cards)
        {
            if (cards.Count(x => x.Suit == RequestStructure.Suit.Clubs) >= 5)
            {
                return true;
            }
            if (cards.Count(x => x.Suit == RequestStructure.Suit.Diamonds) >= 5)
            {
                return true;
            }
            if (cards.Count(x => x.Suit == RequestStructure.Suit.Hearts) >= 5)
            {
                return true;
            }
            if (cards.Count(x => x.Suit == RequestStructure.Suit.Spades) >= 5)
            {
                return true;
            }
            return false;
        }
    }
}