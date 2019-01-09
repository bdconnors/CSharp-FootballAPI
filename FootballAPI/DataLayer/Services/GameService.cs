using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class GameService
    {
        public Game game { get; set; }
        private static Database db;

        public GameService(Game game)
        {
            this.game = game;
            db = new Database();
        }
        public GameService()
        {
            db = new Database();
        }

        public void GetInfo()
        {
            TeamService teamService = new TeamService();
            string sql = "SELECT * FROM Game WHERE Gameid = @Gameid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@Gameid", game.game.gameid } };
            try
            {
                string[] queryResult = db.GetData(sql, values)[0];
                game.game.gameid = queryResult[0];
                game.game.date = queryResult[1];
                game.game.time = queryResult[2];
                game.homeTeam.abbr = queryResult[3];
                game.awayTeam.abbr = queryResult[4];
                teamService.team = game.homeTeam;
                teamService.GetInfo();
                teamService.team = game.awayTeam;
                teamService.GetInfo();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Post()
        {
            int effected = 0;
            string sql = "INSERT INTO Game(Gameid,Date,Time,HomeTeam,AwayTeam)VALUES(@Gameid,@Date,@Time,@HomeTeam,@AwayTeam);";
            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {               values.Add("@Gameid", game.game.gameid);
                values.Add("@Date", game.game.date);
                values.Add("@Time", game.game.time);
                values.Add("@HomeTeam", game.homeTeam.abbr);
                values.Add("@AwayTeam", game.awayTeam.abbr);
                effected = db.SetData(sql, values);
            }
            catch(Exception e)
            {
                effected = -1;
                throw new Exception(e.Message, e);
            }
            return effected;
        }

    }
}