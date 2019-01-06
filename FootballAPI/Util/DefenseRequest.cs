using System.Collections.Generic;
using FootballAPI.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    public class DefenseRequest : Request
    {

        public DefenseRequest(Season season) : base(season)
        {}
        /// <summary>
        /// Gets defensive game statistics of a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <returns></returns>
        public List<DefenseGameStats> GetGameStats(string team)
        {
            string DefGames = "/team_gamelogs.json?team=" + team;
            List<DefenseGameStats> stats = new List<DefenseGameStats>();
            JArray allGames = (JArray)JObject.Parse(Submit(DefGames))["teamgamelogs"]["gamelogs"];
            DefenseGameStats gameStats;
            foreach (JToken game in allGames)
            {
                gameStats = new DefenseGameStats();
                gameStats.team = (string)game["team"]["ID"];
                gameStats.gameid = (string)game["game"]["id"];
                gameStats.pa = (string)game["stats"]["PointsAgainst"]["#text"];
                gameStats.sck = (string)game["stats"]["Sacks"]["#text"];
                gameStats.fum = (string)game["stats"]["FumForced"]["#text"];
                gameStats.intc = (string)game["stats"]["Interceptions"]["#text"];
                gameStats.intTd = (string)game["stats"]["IntTD"]["#text"];
                gameStats.fumTd = (string)game["stats"]["FumTD"]["#text"];
                gameStats.sfty = (string)game["stats"]["Safeties"]["#text"];
                gameStats.krTd = (string)game["stats"]["KrTD"]["#text"];
                gameStats.prTd = (string)game["stats"]["PrTD"]["#text"];
                gameStats.fgBlk = (string)game["stats"]["FgBlk"]["#text"];
                gameStats.xpBlk = (string)game["stats"]["XpBlk"]["#text"];
                stats.Add(gameStats);
            }
            return stats;
        }
        /// <summary>
        /// Gets all defensive season statistics for all 32 NFL teams
        /// </summary>
        /// <returns>List of string[] Containing defensive season stats for all 32 NFL teams</returns>
        public List<DefenseSeasonStats> GetSeasonStats()
        {
            string DefSeason = "/overall_team_standings.json";
            List<DefenseSeasonStats> stats = new List<DefenseSeasonStats>();
            JArray allTeams = (JArray)JObject.Parse(Submit(DefSeason))["overallteamstandings"]["teamstandingsentry"];
            DefenseSeasonStats seasonStats;
            foreach (JToken team in allTeams)
            {
                seasonStats = new DefenseSeasonStats();
                seasonStats.team = (string)team["team"]["ID"];
                seasonStats.pa = (string)team["stats"]["PointsAgainst"]["#text"];
                seasonStats.sck = (string)team["stats"]["Sacks"]["#text"];
                seasonStats.fum = (string)team["stats"]["FumForced"]["#text"];
                seasonStats.intc = (string)team["stats"]["Interceptions"]["#text"];
                seasonStats.intTd = (string)team["stats"]["IntTD"]["#text"];
                seasonStats.fumTd = (string)team["stats"]["FumTD"]["#text"];
                seasonStats.sfty = (string)team["stats"]["Safeties"]["#text"];
                seasonStats.krTd = (string)team["stats"]["KrTD"]["#text"];
                seasonStats.prTd = (string)team["stats"]["PrTD"]["#text"];
                seasonStats.fgBlk = (string)team["stats"]["FgBlk"]["#text"];
                seasonStats.xpBlk = (string)team["stats"]["XpBlk"]["#text"];
                stats.Add(seasonStats);
            }
            return stats;
        }
    }
}
