using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {

        public static dynamic CheckCardsOnHand(JObject gameState)
        {
            dynamic res = new ExpandoObject();
            res.Hand = Hand.Nothing;
            return res;
        }
    }
}