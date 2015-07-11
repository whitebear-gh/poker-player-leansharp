using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public class RequestStructure
    {
        public enum PlayerStatus
        {
            Active,
            Folded,
            Out
        }

        public enum Suit
        {
            Hearts,
            Spades,
            Clubs,
            Diamonds
        }
        public class Card
        {
            public string Rank { get; set; }
            public Suit Suit { get; set; }


        }

        public class Player
        {
            public string Name { get; set; }
            public int Stack { get; set; }
            public int Bet { get; set; }

            public PlayerStatus Status { get; set; }
            public List<Card> HoldCards { get; set; }

            public int Id { get; set; }
            public string Version { get; set; }


        }

        public class GameState
        {
            public GameState(JObject gameState)
            {
                Players = JsonConvert.DeserializeObject<List<Player>>(gameState["players"].ToString());
                TournamentId = gameState["tournament_id"].ToString();
                GameId = gameState["game_id"].ToString();
                Round = Convert.ToInt32(gameState["round"].ToString());
                BetIndex = Convert.ToInt32(gameState["bet_index"].ToString());
                SmallBlind = Convert.ToInt32(gameState["small_blind"].ToString());
                Orbits = Convert.ToInt32(gameState["orbits"].ToString());
                Dealer = gameState["dealer"].ToString();
                CommunityCards = JsonConvert.DeserializeObject<List<Card>>(gameState["community_cards"].ToString());
                CurrentBuyIn = Convert.ToInt32(gameState["current_buy_in"].ToString());
                Pot = Convert.ToInt32(gameState["pot"].ToString());
                InAction = Convert.ToInt32(gameState["in_action"].ToString());
                MinimumRaise = Convert.ToInt32(gameState["minimum_raise"].ToString());
            }
            public List<Player> Players { get; set; }

            public string TournamentId { get; set; }
            public string GameId { get; set; }
            public int Round { get; set; }
            public int BetIndex { get; set; }
            public int SmallBlind { get; set; }
            public int Orbits { get; set; }
            public string Dealer { get; set; }
            public List<Card> CommunityCards { get; set; }
            public int CurrentBuyIn { get; set; }
            public int MinimumRaise { get; set; }
            public int Pot { get; set; }
            public int InAction { get; set; }

            public Player OurPlayer
            {
                get
                {
                    var first = Players.First(player => player.Id == InAction);
                    return first;
                }
            }

            public List<Card> OurCards
            {
                get { return OurPlayer.HoldCards; }
            }

            //          "tournament_id":"550d1d68cd7bd10003000003",
            //"game_id":"550da1cb2d909006e90004b1",
            //"round":0,
            //"bet_index":0,
            //"small_blind":10,
            //"orbits":0,
            //"dealer":0,
            //"community_cards":[],
            //"current_buy_in":0,
            //"pot":0

        }
    }
}