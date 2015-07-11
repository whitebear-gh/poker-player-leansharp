#if !__MonoCS__
using System;
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
    }
}
#endif