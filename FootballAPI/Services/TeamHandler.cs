using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class TeamHandler : IDataAccessLayer<Team>
    {
        public static Database db = new Database();
        public Team obj { get; set; }

        public TeamHandler(Team team)
        {
            obj = team;
        }
        public TeamHandler()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Team WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr", obj.abbr } };
            obj.Set(db.GetData(sql, values)[0]);
        }
        public int Post()
        {
            string sql = "INSERT INTO Team(Abbr,City,Name)VALUES(@Abbr,@City,@Name)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Abbr", obj.abbr);
            values.Add("@City", obj.city);
            values.Add("@Name", obj.name);
            return db.SetData(sql,values);
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