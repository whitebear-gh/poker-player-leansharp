using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;

namespace PokerTests
{
    [TestClass]
    public class CardsOnHandTests
    {
        [TestMethod]
        public void Should_Select_Quantity()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("2", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("10", RequestStructure.Suit.Clubs),
            };

            
        }
    }
}
