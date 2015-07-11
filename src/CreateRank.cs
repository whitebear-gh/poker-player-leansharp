using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
         
 public static dynamic CreateRank(dynamic hand)
        {
            if (hand.Hand == Hand.Pair)
            {
                return null;
            }
            return null;
        }
    }
}