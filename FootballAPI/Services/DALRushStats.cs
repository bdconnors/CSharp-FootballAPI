using System.Collections.Generic;
using FootballAPI.Util;
using FootballAPI.Models;

namespace FootballAPI.Services
{
    class DALRushStats : IDataAccessLayer<RushStats>
    {
        private static Database db = new Database();

        public void Fetch(RushStats stats)
        {
            string sql = "SELECT playerid,rushAtt,rushYds,rushTds,fum FROM rushStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@id", stats.id } };
            string[] queryResult = db.GetData(sql, values)[0];
            stats.playerid = queryResult[0];
            stats.rushAtt = queryResult[1];
            stats.rushYds = queryResult[2];
            stats.rushTds = queryResult[3];
            stats.fum = queryResult[4];
        }
        public int Post(RushStats stats)
        {
            string sql = "INSERT INTO rushStats(id,playerid,rushAtt,rushYds,rushTds,fum)VALUES(@id,@playerid,@rushAtt,@rushYds,@rushTds,@fum)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@id", stats.id);
            values.Add("@playerid", stats.playerid);
            values.Add("@rushAtt", stats.rushAtt);
            values.Add("@rushYds", stats.rushYds);
            values.Add("@rushTds", stats.rushTds);
            values.Add("@fum", stats.fum);
            return db.SetData(sql, values);
        }
        public int Put(RushStats stats)
        {
            string sql = "UPDATE rushStats SET playerid = @playerid,rushAtt = @rushAtt,rushYds = @rushYds,rushTds = @rushTds, fum = @fum WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@playerid", stats.playerid);
            values.Add("@rushAtt", stats.rushAtt);
            values.Add("@rushYds", stats.rushYds);
            values.Add("@rushTds", stats.rushTds);
            values.Add("@fum", stats.fum);
            values.Add("@id", stats.id);
            return db.SetData(sql,values);
        }
        public int Delete(RushStats stats)
        {
            string sql = "DELETE FROM rushStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>(){{"@id", stats.id}};
            return db.SetData(sql, values);
        }
    }
}
