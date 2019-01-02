using System.Collections.Generic;
using FootballAPI.Util;
using FootballAPI.Models;

namespace FootballAPI.Services
{
    class DALRecStats : IDataAccessLayer<RecStats>
    {
        public Database db = new Database();

        public void Fetch(RecStats stats)
        {
            string sql = "SELECT playerid,rec,recYds,recTds FROM recStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>(){{ "@id", stats.id }};
            string[] queryResult = db.GetData(sql, values)[0];
            stats.playerid = queryResult[0];
            stats.rec = queryResult[1];
            stats.recYds = queryResult[2];
            stats.recTds = queryResult[3];
        }
        public int Post(RecStats stats)
        {
            string sql = "INSERT INTO rushStats(id,playerid,rec,recYds,recTds)VALUES(@id,@playerid,@rec,@recYds,@recTds)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@id", stats.id);
            values.Add("@playerid", stats.playerid);
            values.Add("@rec", stats.rec);
            values.Add("@recYds", stats.recYds);
            values.Add("@recTds", stats.recTds);
            return db.SetData(sql, values);
        }
        public int Put(RecStats stats)
        {
            string sql = "UPDATE recStats SET playerid = @playerid,rec = @rec,recYds = @recYds,recTds = @recTds WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@playerid", stats.playerid);
            values.Add("@rec", stats.rec);
            values.Add("@recYds", stats.recYds);
            values.Add("@recTds", stats.recTds);
            values.Add("@id", stats.id);
            return db.SetData(sql,values);
        }
        public int Delete(RecStats stats)
        {
            string sql = "DELETE FROM recStats WHERE id = @id";
            Dictionary<string, string> values = new Dictionary<string, string>(){{"@id", stats.id}};
            return db.SetData(sql, values);
        }
    }
}
