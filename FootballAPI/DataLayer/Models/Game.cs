using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Game
    {
        public GameInfo game { get; set; }
        public Team homeTeam { get; set; }
        public Team awayTeam { get; set; }

        public Game(GameInfo game,Team homeTeam,Team awayTeam)
        {
            this.game = game;
            this.homeTeam = homeTeam;
            this.awayTeam = awayTeam;
        }
        public Game(GameInfo game)
        {
            this.game = game;
        }
        public Game()
        {
            game = new GameInfo();
            homeTeam = new Team();
            awayTeam = new Team();
        }
    }
}