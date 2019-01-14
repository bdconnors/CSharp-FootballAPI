using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class DefenseGameStats
    {
        public Game game { get; set; }
        public DefenseStats stats { get; set; }

        public DefenseGameStats(Game game, DefenseStats stats)
        {
            this.game = game;
            this.stats = stats;
        }
        public DefenseGameStats(Game game)
        {
            this.game = game;
        }
        public DefenseGameStats()
        {
            game = new Game();
            stats = new DefenseStats();
        }
    }
}