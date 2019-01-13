using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class GameService : Database
    {
        public Game game { get; set; }
        private static Database db;

        public GameService(Game game)
        {
            this.game = game;
        }
        public GameService()
        { }
        
        public void Get()
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string> { { "@GameID", game.gameid } };
                string[] result = SelectProc("GetGame", values)[0];
                game.gameid = result[0];
                game.date = result[1];
                game.time = result[2];
                game.homeTeam.abbr = result[3];
                game.homeTeam.city = result[4];
                game.homeTeam.name = result[5];
                game.awayTeam.abbr = result[6];
                game.awayTeam.city = result[7];
                game.awayTeam.name = result[8];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Insert()
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@GameID", game.gameid);
                values.Add("@Date", game.date);
                values.Add("@Time", game.time);
                values.Add("@HomeTeam", game.homeTeam.abbr);
                values.Add("@AwayTeam", game.awayTeam.abbr);
                effected = UpdateProc("InsertGame", values);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}