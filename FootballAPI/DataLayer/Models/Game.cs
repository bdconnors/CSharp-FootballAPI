using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Game
    {
        public string gameid { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public Team homeTeam { get; set; }
        public Team awayTeam { get; set; }

        public Game(string gameid)
        {
            this.gameid = gameid;
            homeTeam = new Team();
            awayTeam = new Team();
        }
        public Game()
        {
            homeTeam = new Team();
            awayTeam = new Team();
        }
    }
}