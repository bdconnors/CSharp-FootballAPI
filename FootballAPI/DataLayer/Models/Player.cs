using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Player
    {
        public PlayerInfo player{get;set;}
        public Team team { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PlayerStats seasonLog {get; set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PlayerGameStats> gameLogs {get; set;}


        public Player(string playerid)
        {
            player = new PlayerInfo(playerid);
            team = new Team();
        }
        public Player()
        {
            player = new PlayerInfo();
            team = new Team();
        }
    }
}