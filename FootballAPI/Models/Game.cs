using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Game
    {
        public string gameid { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string homeTeam { get; set; }
        public string awayTeam { get; set; }

        public Game(string gameid)
        {
            this.gameid = gameid;
        }
        public Game()
        {

        }
        public void Set(string[] info)
        {
            gameid = info[0];
            date = info[1];
            time = info[2];
            homeTeam = info[3];
            awayTeam = info[4];
        }
        public string[] Get()
        {
            string[] info = new string[5];
            info[0] = gameid;
            info[1] = date;
            info[2] = time;
            info[3] = homeTeam;
            info[4] = awayTeam;
            return info;
        }
    }
}