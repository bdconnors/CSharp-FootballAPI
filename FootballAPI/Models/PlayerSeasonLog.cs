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

        public PlayerSeasonLog(Player player)
        {
            this.player = player;

        }
        public PlayerSeasonLog()
        {

        }
    }
}