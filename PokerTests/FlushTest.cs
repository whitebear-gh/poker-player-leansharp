﻿#if !__MonoCS__
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;

namespace PokerTests
{
    [TestClass]
    public class FlushTest
    {
        private JObject gamestate;

        [TestMethod]
        public void IsTwoCardsNothingTest()
        {
            var content = File.ReadAllText("..\\..\\gamestate.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CheckCardsForFlush(state.CommunityCards.Concat(state.OurPlayer.HoleCards).ToList());
            Assert.AreEqual(result, Hand.Nothing);
        }

        [TestMethod]
        public void IsFlushFlushTest()
        {
            var content = File.ReadAllText("..\\..\\gamestateFlush.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CheckCardsForFlush(state.CommunityCards.Concat(state.OurPlayer.HoleCards).ToList());
            Assert.AreEqual(result, Hand.Flush);
        }

        [TestMethod]
        public void Should_Flush()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("J", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("Q", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("A", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.Flush);
        }

        [TestMethod]
        public void Should_StraightFlush()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("2", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("4", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("5", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("6", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.StraightFlush);
        }

        [TestMethod]
        public void Should_Straight()
        {
            var cardsOverall = new List<RequestStructure.Card>
            {
                new RequestStructure.Card ("2", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("3", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("4", RequestStructure.Suit.Spades),
                new RequestStructure.Card ("5", RequestStructure.Suit.Clubs),
                new RequestStructure.Card ("6", RequestStructure.Suit.Clubs),
            };
            var hand = PokerPlayer.CheckCardsOnHand(cardsOverall);

            Assert.AreEqual(hand, Hand.Straight);
        }
    }
}
#endif
