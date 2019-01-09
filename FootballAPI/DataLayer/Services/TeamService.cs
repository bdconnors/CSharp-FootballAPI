using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class TeamService
    {
        public Team team { get; set; }
        public static Database db { get; set; }

        public TeamService(Team team)
        {
            this.team = team;
            db = new Database();
        }
        public TeamService()
        {
            db = new Database();
        }

        public void GetInfo()
        {
            string sql = "SELECT * FROM Team WHERE abbr = @abbr";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr",team.abbr} };
            try
            {
                string[] queryResult = db.GetData(sql, values)[0];
                team.abbr = queryResult[0];
                team.city = queryResult[1];
                team.name = queryResult[2];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Post()
        {
            int effected = 0;
            string sql = "INSERT INTO Team(abbr,city,name)VALUES(@abbr,@city,@name)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@abbr", team.abbr);
            values.Add("@city", team.city);
            values.Add("@name", team.name);
            try
            {
                effected = db.SetData(sql, values);
            }
            catch(Exception e)
            {
                effected = -1;
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}