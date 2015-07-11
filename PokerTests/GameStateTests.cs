#if !__MonoCS__
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

            Assert.IsTrue(state.TournamentId == "550d1d68cd7bd10003000003");
            Assert.IsTrue(state.GameId == "550da1cb2d909006e90004b1"); 
            Assert.IsTrue(state.Round == 0);
            Assert.IsTrue(state.BetIndex == 0);
            Assert.IsTrue(state.SmallBlind == 10);
            Assert.IsTrue(state.CurrentBuyIn == 320);
            Assert.IsTrue(state.Pot == 400);
            Assert.IsTrue(state.MinimumRaise == 240);
            Assert.IsTrue(state.Dealer== "1");
            Assert.IsTrue(state.Orbits == 7);
            Assert.IsTrue(state.InAction == 1);


            var cards = state.CommunityCards;
            Assert.IsNotNull(cards);
            Assert.IsTrue(cards.Count ==3);
            var card = cards.First();
            Assert.IsTrue(card.Rank == "4");
            Assert.IsTrue(card.Suit== RequestStructure.Suit.Spades);

            var players= state.Players;
            Assert.IsNotNull(players);
            Assert.IsTrue(players.Count == 3);
            var player = players[1];
            Assert.IsTrue(player.Id== 1);
            Assert.IsTrue(player.Name== "Bob");
            Assert.IsTrue(player.Status== RequestStructure.PlayerStatus.Active);
            Assert.IsTrue(player.Version == "Default random player");
            Assert.IsTrue(player.Stack== 1590);
            Assert.IsTrue(player.Bet== 80);

            var ourPlayer = state.OurPlayer;
            Assert.AreEqual(ourPlayer.Name,"Bob");


            Assert.IsNotNull(state);

        }
    }

}


#endif