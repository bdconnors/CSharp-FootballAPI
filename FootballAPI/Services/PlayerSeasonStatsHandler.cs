using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerSeasonStatsHandler : IDataAccessLayer<PlayerSeasonStats>
    {
        public static Database db = new Database();
        public PlayerSeasonStats obj { get; set; }

        public PlayerSeasonStatsHandler(PlayerSeasonStats seasonStats)
        {
            obj = seasonStats;
        }
        public PlayerSeasonStatsHandler()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM PlayerSeasonStats WHERE playerid = @playerid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@playerid", obj.playerid } };
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