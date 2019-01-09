using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class PlayerInfo
    {
        public string playerid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string number { get; set; }
        public string position { get; set; }

        public PlayerInfo(string playerid)
        {
            this.playerid = playerid;
        }
        public PlayerInfo()
        {

        }
    }
}