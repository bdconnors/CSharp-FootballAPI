using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class PlayerGameLogs
    {
        public List<Player> playergamelogs { get; set; }
        public PlayerGameLogs()
        {
            playergamelogs = new List<Player>();
        }
    }
}