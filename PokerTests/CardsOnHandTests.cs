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
        public void IsFullHouseTest()
        {
            Assert.IsTrue(PokerPlayer.IsFullHouse(
                new List<RequestStructure.Card>() {
                    new RequestStructure.Card("2", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("2", RequestStructure.Suit.Hearts)
                }));

            Assert.IsTrue(PokerPlayer.IsFullHouse(
                new List<RequestStructure.Card>() {
                    new RequestStructure.Card("1", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("2", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("4", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("4", RequestStructure.Suit.Hearts)
                }));

            Assert.IsFalse(PokerPlayer.IsFullHouse(
                    new List<RequestStructure.Card>() {
                    new RequestStructure.Card("2", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                }));

            Assert.IsFalse(PokerPlayer.IsFullHouse(
                    new List<RequestStructure.Card>() {
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                }));
        }

        [TestMethod]
        public void IsFourOfKindTest()
        {
            Assert.IsTrue(PokerPlayer.IsFourOfKind(
                new List<RequestStructure.Card>() {
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("2", RequestStructure.Suit.Hearts)
                }));

            Assert.IsTrue(PokerPlayer.IsFourOfKind(
                new List<RequestStructure.Card>() {
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("3", RequestStructure.Suit.Hearts)
                }));

            Assert.IsFalse(PokerPlayer.IsFourOfKind(
                    new List<RequestStructure.Card>() {
                    new RequestStructure.Card("2", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Spades),
                }));

            Assert.IsFalse(PokerPlayer.IsFourOfKind(
                    new List<RequestStructure.Card>() {
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("3", RequestStructure.Suit.Diamonds),
                    new RequestStructure.Card("3", RequestStructure.Suit.Clubs),
                    new RequestStructure.Card("2", RequestStructure.Suit.Spades),
                    new RequestStructure.Card("2", RequestStructure.Suit.Spades),
                }));
        }

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