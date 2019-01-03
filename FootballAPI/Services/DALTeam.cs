using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FootballAPI.Util;
using FootballAPI.Models;

namespace FootballAPI.Services
{
    public class DALTeam : IDataAccessLayer<Team>
    {
        private static Database db = new Database();

        public void Fetch(Team team)
        {
            string sql = "SELECT name FROM teams WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr", team.abbr } };
            string[] queryResult = db.GetData(sql, values)[0];
            team.name = queryResult[0];
        }
        public int Post(Team team)
        {
            string sql = "INSERT INTO teams(abbr,name)VALUES(@abbr,@name)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@abbr", team.abbr);
            values.Add("@name", team.name);
            return db.SetData(sql, values);
        }
        public int Put(Team team)
        {
            string sql = "UPDATE teams SET name = @name WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@name", team.name);
            values.Add("@abbr", team.abbr);
            return db.SetData(sql, values);
        }
        public int Delete(Team team)
        {
            string sql = "DELETE FROM teams WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr", team.abbr } };
            return db.SetData(sql, values);
        }
    }   
}