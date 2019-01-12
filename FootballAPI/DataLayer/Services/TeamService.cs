using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class TeamService : Database
    {
        public Team team { get; set; }

        public TeamService(Team team)
        {
            this.team = team;
        }
        public TeamService()
        {
        }

        public void GetTeam()
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@abbr", team.abbr } };
                string[] results = SelectProc("GetTeam", values)[0];
                team.abbr = results[0];
                team.city = results[1];
                team.name = results[2];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int InsertTeam()
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Abbr", team.abbr);
                values.Add("@City", team.city);
                values.Add("@Name", team.name);
                effected = UpdateProc("InsertTeam", values);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}