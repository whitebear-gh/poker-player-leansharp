#if !__MonoCS__

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
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand,Hand.Nothing);
        }


        [TestMethod]
        public void Should_Select_Quantity2()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.FullHouse);
        }



        [TestMethod]
        public void Should_Select_Quantity3()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.ThreeOfKind);
        }


        [TestMethod]
        public void Should_Select_Quantity4()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.TwoPair);
        }


        [TestMethod]
        public void Should_Select_Quantity5()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("f", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.Pair);
        }










    }
}

#endif