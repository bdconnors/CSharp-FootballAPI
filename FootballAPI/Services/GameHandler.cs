using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class GameHandler : IDataAccessLayer<Game>
    {
        public static Database db = new Database();
        public Game obj { get; set; }

        public GameHandler(Game game)
        {
            obj = game;
        }
        public GameHandler()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Game WHERE gameid = @gameid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@gameid", obj.gameid } };
            obj.Set(db.GetData(sql, values)[0]);
        }
        public int Post()
        {
            string sql = "INSERT INTO Game(Gameid,Date,Time,HomeTeam,AwayTeam)VALUES(@gameid,@date,@time,@hometeam,@awayteam)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@gameid", obj.gameid);
            values.Add("@date", obj.date);
            values.Add("@time", obj.time);
            values.Add("@hometeam", obj.homeTeam);
            values.Add("@awayteam", obj.awayTeam);
            return db.SetData(sql, values);
        }
        public int Put()
        {
            return 0;
        }
        public int Delete()
        {
            return 0;
        }
        public bool Exists()
        {
            bool exists = true;
            string sql = "SELECT Gameid FROM Game WHERE Gameid = @gameid LIMIT 1";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@gameid", obj.gameid } };
            if (db.GetData(sql, values).Count == 0)
            {
                exists = false;
            }
            return exists;
        }
    }
}