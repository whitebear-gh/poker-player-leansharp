using System;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
	public static partial class PokerPlayer
	{
		public static readonly string VERSION = "Default C# folding player";



        /// <summary>
        /// Use this method to return the value You want to bet
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
		public static int BetRequest(JObject gameState)
		{
            try
            {
                dynamic hand = CheckCardsOnHand(gameState);
                dynamic rank = CreateRank(hand);
                int bet = CalculateBet(gameState, rank);

                return bet;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message + "\n\t" + e.StackTrace);
                
                return 200;
            }
		}

		public static void ShowDown(JObject gameState)
		{
			//TODO: Use this method to showdown
		}




       

	}
}

