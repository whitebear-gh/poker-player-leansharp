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
        public void GetRankTest()
        {
            var content = File.ReadAllText("..\\..\\gamestate.json");
            gamestate = JObject.Parse(content);

            var result = PokerPlayer.CreateRank(gamestate);
        }
    }
}
