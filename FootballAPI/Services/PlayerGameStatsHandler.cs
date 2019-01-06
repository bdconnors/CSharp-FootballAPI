using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerGameStatsHandler : IDataAccessLayer<PlayerGameStats>
    {
        public static Database db = new Database();
        public PlayerGameStats obj { get; set; }

        public PlayerGameStatsHandler(PlayerGameStats gameStats)
        {
            obj = gameStats;
        }
        public PlayerGameStatsHandler()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM PlayerGameStats WHERE Playerid = @Playerid AND Gameid = @Gameid";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid", obj.playerid);
            values.Add("@Gameid", obj.gameid);
            obj.Set(db.GetData(sql, values)[0]);   
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