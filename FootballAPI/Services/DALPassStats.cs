using System.Collections.Generic;
using FootballAPI.Util;
using FootballAPI.Models;

namespace FootballAPI.Services
{
    class DALPassStats : IDataAccessLayer<PassStats>
    {
        private static Database db = new Database();

        public void Fetch(PassStats stats)
        {
            string sql = "SELECT playerid,passAtt,passComp,passYds,passTds,intc FROM passStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@id", stats.id } };
            string[] queryResult = db.GetData(sql, values)[0];
            stats.playerid = queryResult[0];
            stats.passAtt = queryResult[1];
            stats.passComp = queryResult[2];
            stats.passYds = queryResult[3];
            stats.passTds = queryResult[4];
            stats.intc = queryResult[5];
        }
        public int Post(PassStats stats)
        {
            string sql = "INSERT INTO passStats(id,playerid,passAtt,passComp,passYds,passTds,intc)VALUES(@id,@playerid,@passAtt,@passComp,@passYds,@passTds,@intc)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@id", stats.id);
            values.Add("@playerid", stats.playerid);
            values.Add("@passAtt", stats.passAtt);
            values.Add("@passComp", stats.passComp);
            values.Add("@passYds", stats.passYds);
            values.Add("@passTds", stats.passTds);
            values.Add("@intc", stats.intc);
            return db.SetData(sql, values);
        }
        public int Put(PassStats stats)
        {
            string sql = "UPDATE passStats SET playerid = @playerid,passAtt = @passAtt,passComp = @passComp,passYds = @passYds,passTds = @passTds,intc = @intc WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@playerid", stats.playerid);
            values.Add("@passAtt", stats.passAtt);
            values.Add("@passComp", stats.passComp);
            values.Add("@passYds", stats.passYds);
            values.Add("@passTds", stats.passTds);
            values.Add("@intc", stats.intc);
            values.Add("@id", stats.id);
            return db.SetData(sql,values);
        }
        public int Delete(PassStats stats)
        {
            string sql = "DELETE FROM passStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>(){{"@id", stats.id}};
            return db.SetData(sql, values);
        }
    }
}
