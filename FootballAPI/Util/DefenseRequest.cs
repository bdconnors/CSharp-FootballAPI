using System.Collections.Generic;
using FootballAPI.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    class DefenseRequest : Request
    {

        public DefenseRequest(Season season) : base(season)
        {}
        /// <summary>
        /// Gets defensive game statistics of a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <returns></returns>
        public List<string[]> GetDefGameStats(string team)
        {
            string DefGames = "/team_gamelogs.json?team=" + team;
            List<string[]> stats = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(DefGames))["rosterplayers"]["playerentry"];
            string[] playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new string[6];
                stats.Add(playerStats);
            }
            return stats;
        }
        /// <summary>
        /// Gets all defensive season statistics for all 32 NFL teams
        /// </summary>
        /// <returns>List of string[] Containing defensive season stats for all 32 NFL teams</returns>
        public List<string[]> GetDefSeasonStats()
        {
            string DefSeason = "/overall_team_standings.json";
            List<string[]> stats = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(DefSeason))["rosterplayers"]["playerentry"];
            string[] playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new string[6];
                stats.Add(playerStats);
            }
            return stats;
        }
    }
}
