using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerSeasonStatsAccess : IDataAccessLayer<PlayerSeasonStats>
    {
        public static Database db = new Database();
        public PlayerSeasonStats obj { get; set; }

        public PlayerSeasonStatsAccess(PlayerSeasonStats seasonStats)
        {
            obj = seasonStats;
        }
        public PlayerSeasonStatsAccess()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM PlayerSeasonStats WHERE playerid = @playerid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@playerid", obj.playerid } };
            string[] queryResult = db.GetData(sql, values)[0];
            obj.gamesPlayed = queryResult[1];
            obj.passAtt = queryResult[2];
            obj.passComp = queryResult[3];
            obj.passYds = queryResult[4];
            obj.passTds = queryResult[5];
            obj.intc = queryResult[6];
            obj.rushAtt = queryResult[7];
            obj.rushYds = queryResult[8];
            obj.rushTds = queryResult[9];
            obj.fum = queryResult[10];
            obj.rec = queryResult[11];
            obj.recYds = queryResult[12];
            obj.fgAtt = queryResult[13];
            obj.fgMade = queryResult[14];
            obj.xpAtt = queryResult[15];
            obj.fgPct = queryResult[16];
            obj.xpPct = queryResult[17];
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