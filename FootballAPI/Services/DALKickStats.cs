using System.Collections.Generic;
using FootballAPI.Util;
using FootballAPI.Models;

namespace FootballAPI.Services
{
    class DALKickStats : IDataAccessLayer<KickStats>
    {
        private static Database db = new Database();
        
        public void Fetch(KickStats stats)
        {
            string sql = "SELECT playerid,fgAtt,fgMade,xpAtt,xpMade FROM kickStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@id", stats.id } };
            string[] queryResult = db.GetData(sql, values)[0];
            stats.playerid = queryResult[0];
            stats.fgAtt = queryResult[1];
            stats.fgMade = queryResult[2];
            stats.xpAtt = queryResult[3];
            stats.xpMade = queryResult[4];
        }
        public int Post(KickStats stats)
        {
            string sql = "INSERT INTO kickStats(id,playerid,fgAtt,fgMade,xpAtt,xpMade)VALUES(@id,@playerid,@fgAtt,@fgMade,@xpAtt,@xpMade)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@id", stats.id);
            values.Add("@playerid", stats.playerid);
            values.Add("@fgAtt", stats.fgAtt);
            values.Add("@fgMade", stats.fgMade);
            values.Add("@xpAtt", stats.xpAtt);
            values.Add("@xpMade", stats.xpMade);
            return db.SetData(sql, values);
        }
        public int Put(KickStats stats)
        {
            string sql = "UPDATE passStats SET playerid = @playerid,fgAtt = @fgAtt,fgMade = @fgMade,xpAtt = @xpAtt,xpMade = @xpMade WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@playerid", stats.playerid);
            values.Add("@fgAtt", stats.fgAtt);
            values.Add("@fgMade", stats.fgMade);
            values.Add("@xpAtt", stats.xpAtt);
            values.Add("@xpMade", stats.xpMade);
            values.Add("@id", stats.id);
            return db.SetData(sql,values);
        }
        public int Delete(KickStats stats)
        {
            string sql = "DELETE FROM kickStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>(){{"@id", stats.id}};
            return db.SetData(sql, values);
        }
    }
}
