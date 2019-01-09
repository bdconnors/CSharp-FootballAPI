using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class GameInfo
    {
        public string gameid { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public GameInfo(string gameid)
        {
            this.gameid = gameid;
        }
        public GameInfo()
        {

        }
    }
}