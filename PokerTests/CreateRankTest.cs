#if !__MonoCS__
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;

namespace PokerTests
{
    [TestClass]
    public class CreateRankTest
    {
        private JObject gamestate;

        [TestMethod]
        public void IsNullForSecondRound()
        {
            var content = File.ReadAllText("..\\..\\gamestate.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CreateRank(state);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsNotNullForFirstRound()
        {
            var content = File.ReadAllText("..\\..\\gamestateFirstRound.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CreateRank(state);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IsTwoAces315PointsRound()
        {
            var content = File.ReadAllText("..\\..\\gamestateTwoAces.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CreateRank(state);
            Assert.AreEqual(result.Value, (int)StartingHandRanking.AA);
        }

        [TestMethod]
        public void IsAceKingSame221PointsRound()
        {
            var content = File.ReadAllText("..\\..\\gamestateAceKingSame.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CreateRank(state);
            Assert.AreEqual(result.Value, (int)StartingHandRanking.AKs);
        }

        [TestMethod]
        public void IsKingAceOther221PointsRound()
        {
            var content = File.ReadAllText("..\\..\\gamestateKingAceOther.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

            var result = PokerPlayer.CreateRank(state);
            Assert.AreEqual(result.Value, (int)StartingHandRanking.AKo);
        }

        [TestMethod]
        public void TestCreateRankDoesNotCrrash()
        {
            var content = File.ReadAllText("..\\..\\gamestateKingAceOther.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);


            state.OurCards.Clear();
            state.OurCards.Add(new RequestStructure.Card() { Rank = "2", Suit = RequestStructure.Suit.Hearts });
            state.OurCards.Add(new RequestStructure.Card() { Rank = "10", Suit = RequestStructure.Suit.Clubs });
            PokerPlayer.CreateRank(state);
        }
    }
}
#endif