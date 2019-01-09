using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Player
    {
        public PlayerInfo player { get; set; }
        public Team team { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PlayerStats seasonLog {get; set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<PlayerGameStats> gameLogs {get; set;}

        public Player(PlayerInfo player, Team team, PlayerStats seasonLog,List<PlayerGameStats> gameLogs)
        {
            this.player = player;
            this.team = team;
            this.seasonLog = seasonLog;
            this.gameLogs = gameLogs;
        }
        public Player(PlayerInfo player, Team team,List<PlayerGameStats> gameLogs)
        {
            this.player = player;
            this.team = team;
            this.gameLogs = gameLogs;
        }
        public Player(PlayerInfo player,Team team,PlayerStats seasonLog)
        {
            this.player = player;
            this.team = team;
            this.seasonLog = seasonLog;
        }
        public Player(PlayerInfo player,Team team)
        {
            this.player = player;
            this.team = team;
        }
        public Player(PlayerInfo player)
        {
            this.player = player;
        }
        public Player()
        {

        }
    }
}