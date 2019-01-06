using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class PlayerGameLog 
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public Game game { get; set; }
        public PlayerGameStats stats { get; set; }
        
        public PlayerGameLog(Player player,Game game)
        {
            this.player = player;
            this.game = game;
        }
        public PlayerGameLog()
        {

        }


    }
}