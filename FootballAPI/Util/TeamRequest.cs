using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    class TeamRequest: Request 
    {
        public TeamRequest(string season, bool regularSeason) : base(season, regularSeason)
        { }
        public TeamRequest(bool regularSeason) : base(regularSeason)
        { }
        /// <summary>
        /// Gets all 32 NFL Team names and their abbreviations
        /// </summary>
        /// <returns>List of string[] Containing all 32 NFL Team names and their abbreviations</returns>
        public List<string[]> GetTeams()
        {
            string OverallTeams = "/overall_team_standings.json";
            List<string[]> teams = new List<string[]>();
            JArray allTeams = (JArray)JObject.Parse(Submit(OverallTeams).Result)["overallteamstandings"]["teamstandingsentry"];
            string[] teamInfo = null;
            foreach (JToken team in allTeams)
            {
                teamInfo = new string[2];
                teamInfo[0] = (string)team["team"]["Abbreviation"];
                teamInfo[1] = (string)team["team"]["City"] + " " + (string)team["team"]["Name"];
                teams.Add(teamInfo);
            }
            return teams;
        }
        /// <summary>
        /// Gets information for all games played by a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <returns>List string[] Containing information for all games played by specified NFL team</returns>
        public List<string[]> GetTeamGames(string team)
        {
            string TeamGames = "/team_gamelogs.json?team=" + team;
            List<string[]> games = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(TeamGames).Result)["rosterplayers"]["playerentry"];
            string[] playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new string[6];
                games.Add(playerStats);
            }
            return games;
        }
    }
}
