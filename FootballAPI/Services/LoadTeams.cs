using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FootballAPI.Services
{
    public class LoadTeams
    {
        private TeamRequest request;

        public LoadTeams(int year)
        {
            request = new TeamRequest(new Season(year.ToString()));
        }

        public int Load()
        {
            List<string[]> teams = request.GetTeams();
            DALTeam service = new DALTeam();
            Team team;
            int rowsEffected = 0;
            foreach(string[] teamInfo in teams)
            {
                team = new Team(teamInfo);
                rowsEffected += service.Post(team);
            }
            return rowsEffected;
        }
    }
}