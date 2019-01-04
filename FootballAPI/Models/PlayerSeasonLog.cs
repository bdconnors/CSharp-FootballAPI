using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class PlayerSeasonLog
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public PlayerSeasonStats stats {get; set;}

        public PlayerSeasonLog(string playerid)
        {
            player = new Player(playerid);

        }
        public PlayerSeasonLog(string fname,string lname)
        {
            player.fname = fname;
            player.lname = lname;
        }
    }
}