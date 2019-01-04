using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerGameStatsAccess : IDataAccessLayer<PlayerGameStats>
    {
        public static Database db = new Database();
        public PlayerGameStats obj { get; set; }

        public PlayerGameStatsAccess(PlayerGameStats gameStats)
        {
            obj = gameStats;
        }
        public PlayerGameStatsAccess()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM PlayerGameStats WHERE Playerid = @Playerid AND Gameid = @Gameid";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid", obj.playerid);
            values.Add("@Gameid", obj.gameid);
            string[] queryResults = db.GetData(sql, values)[0];
            obj.passAtt = queryResults[2];
            obj.passComp = queryResults[3];
            obj.passYds = queryResults[4];
            obj.passTds = queryResults[5];
            obj.intc = queryResults[6];
            obj.rushAtt = queryResults[7];
            obj.rushYds = queryResults[8];
            obj.rushTds = queryResults[9];
            obj.fum = queryResults[10];
            obj.rec = queryResults[11];
            obj.recYds = queryResults[12];
            obj.fgAtt = queryResults[13];
            obj.fgMade = queryResults[14];
            obj.xpAtt = queryResults[15];
            obj.fgPct = queryResults[16];
            obj.xpPct = queryResults[17];
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