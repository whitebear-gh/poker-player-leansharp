using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Nancy.Simple
{
    public static partial class PokerPlayer
    {
        private static int NextRoundRank(Hand hand)
        {
            return (int)hand;
        }
    }
}
