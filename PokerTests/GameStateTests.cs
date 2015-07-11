using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Tests
{
    public class GameStateTests
    {
        private JObject gamestate;

        public GameStateTests()
        {
            var content  = File.ReadAllText("gamestate.json");
            gamestate = new JObject(content);
        }

        [Fact]
        public void test_deserialization()
        {
            var s = gamestate;
            var state = new RequestStructure.GameState(s);

        }
    }

}
