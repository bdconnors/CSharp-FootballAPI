using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class TeamAccess : IDataAccessLayer<Team>
    {
        public static Database db = new Database();
        public Team obj { get; set; }

        public TeamAccess(Team team)
        {
            obj = team;
        }
        public TeamAccess()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Team WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr", obj.abbr } };
            string[] queryResult = db.GetData(sql, values)[0];
            obj.city = queryResult[1];
            obj.name = queryResult[2];
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