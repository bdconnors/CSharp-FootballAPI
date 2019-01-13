using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class PlayerInfoLog
    {
        public List<Player> playerinformation { get; set; }
        public PlayerInfoLog()
        {
            playerinformation = new List<Player>();
        }
    }
}