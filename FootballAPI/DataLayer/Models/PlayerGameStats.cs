using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class PlayerGameStats
    {
        public Game game { get; set; }
        public PlayerStats stats { get; set; }

        public PlayerGameStats(Game game,PlayerStats stats)
        {
            this.game = game;
            this.stats = stats;
        }
        public PlayerGameStats(Game game)
        {
            this.game = game;
            stats = new PlayerStats();
        }
        public PlayerGameStats()
        {
            game = new Game();
            stats = new PlayerStats();
        }
    }
}