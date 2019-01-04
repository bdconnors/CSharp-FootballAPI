using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class GameAccess : IDataAccessLayer<Game>
    {
        public static Database db = new Database();
        public Game obj { get; set; }

        public GameAccess(Game game)
        {
            obj = game;
        }
        public GameAccess()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Game WHERE gameid = @gameid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@gameid", obj.gameid } };
            string[] queryResults = db.GetData(sql, values)[0];
            obj.date = queryResults[1];
            obj.time = queryResults[2];
            obj.homeTeam = queryResults[3];
            obj.awayTeam = queryResults[4];
        }
        public int Post()
        {
            return 0;
        }
        public int Put()
        {
            return 0;
        }
        public int Delete()
        {
            return 0;
        }
    }
}