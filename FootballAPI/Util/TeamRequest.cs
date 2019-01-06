using System.Collections.Generic;
using FootballAPI.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    public class TeamRequest: Request 
    {
        public TeamRequest(Season season) : base(season)
        { }
        /// <summary>
        /// Gets all 32 NFL Team names and their abbreviations
        /// </summary>
        /// <returns>List of string[] Containing all 32 NFL Team names and their abbreviations</returns>
        public List<Team> GetTeams()
        {
            string OverallTeams = "/overall_team_standings.json";
            List<Team> teams = new List<Team>();
            JArray allTeams = (JArray)JObject.Parse(Submit(OverallTeams))["overallteamstandings"]["teamstandingsentry"];
            Team team;
            foreach (JToken teamInfo in allTeams)
            {
                team = new Team();
                team.abbr = (string)teamInfo["team"]["Abbreviation"];
                team.city = (string)teamInfo["team"]["City"];
                team.name = (string)teamInfo["team"]["Name"];
                teams.Add(team);
            }
            return teams;
        }
    }
}
