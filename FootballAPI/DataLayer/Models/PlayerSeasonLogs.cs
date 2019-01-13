using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class PlayerSeasonLogs
    {
        public List<Player> playerseasonlogs{ get; set; }
        public PlayerSeasonLogs()
        {
            playerseasonlogs = new List<Player>();
        }
    }
}