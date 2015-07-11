#if !MONO
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Simple;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 

namespace Tests
{
    [TestClass]
    public class GameStateTests
    {
        private JObject gamestate;

        

        [TestMethod]
        public void test_deserialization()
        {
            //var s = gamestate;
            var content = File.ReadAllText("..\\..\\gamestate.json");
            gamestate = JObject.Parse(content);
            var state = new RequestStructure.GameState(gamestate);

        }
    }

}


#endif