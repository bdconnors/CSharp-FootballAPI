using System.Collections.Generic;
using System.Threading;
using FootballAPI.DataLayer.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.DataLayer.Util
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
        public List<Defense> GetGameStats()
        {
            List<Team> teams = new TeamRequest(new Season(season.year, season.playoffs)).GetTeams();
            List<Defense> defenses = new List<Defense>();
            foreach (Team team in teams)
            {
                Thread.Sleep(10000);
                string DefGames = "/team_gamelogs.json?team=" + team.abbr;
                JArray allGames = (JArray)JObject.Parse(Submit(DefGames))["teamgamelogs"]["gamelogs"];
                Team currentTeam = team;
                Game currentGame;
                DefenseStats currentStats;
                DefenseGameStats currentGameStats;
                Defense currentDefense = new Defense(currentTeam, new List<DefenseGameStats>());
                foreach (JToken game in allGames)
                {              
                    currentGame = new Game((string)game["game"]["id"]);
                    currentStats = new DefenseStats();
                    currentStats.pa = (string)game["stats"]["PointsAgainst"]["#text"];
                    currentStats.sck = (string)game["stats"]["Sacks"]["#text"];
                    currentStats.fum = (string)game["stats"]["FumForced"]["#text"];
                    currentStats.intc = (string)game["stats"]["Interceptions"]["#text"];
                    currentStats.intTd = (string)game["stats"]["IntTD"]["#text"];
                    currentStats.fumTd = (string)game["stats"]["FumTD"]["#text"];
                    currentStats.sfty = (string)game["stats"]["Safeties"]["#text"];
                    currentStats.krTd = (string)game["stats"]["KrTD"]["#text"];
                    currentStats.prTd = (string)game["stats"]["PrTD"]["#text"];
                    currentStats.fgBlk = (string)game["stats"]["FgBlk"]["#text"];
                    currentStats.xpBlk = (string)game["stats"]["XpBlk"]["#text"];
                    currentGameStats = new DefenseGameStats(currentGame, currentStats);
                    currentDefense.gameLogs.Add(currentGameStats);
                }
                defenses.Add(currentDefense);
            }
            Thread.Sleep(10000);
            return defenses;
        }
        /// <summary>
        /// Gets all defensive season statistics for all 32 NFL teams
        /// </summary>
        /// <returns>List of string[] Containing defensive season stats for all 32 NFL teams</returns>
        public List<Defense> GetSeasonStats()
        {
            string DefSeason = "/overall_team_standings.json";
            List<Defense> defenses = new List<Defense>();
            JArray allTeams = (JArray)JObject.Parse(Submit(DefSeason))["overallteamstandings"]["teamstandingsentry"];
            Defense currentDefense;
            Team currentTeam;
            DefenseStats currentStats;
            foreach (JToken team in allTeams)
            {

                currentStats = new DefenseStats();
                currentStats.pa = (string)team["stats"]["PointsAgainst"]["#text"];
                currentStats.sck = (string)team["stats"]["Sacks"]["#text"];
                currentStats.fum = (string)team["stats"]["FumForced"]["#text"];
                currentStats.intc = (string)team["stats"]["Interceptions"]["#text"];
                currentStats.intTd = (string)team["stats"]["IntTD"]["#text"];
                currentStats.fumTd = (string)team["stats"]["FumTD"]["#text"];
                currentStats.sfty = (string)team["stats"]["Safeties"]["#text"];
                currentStats.krTd = (string)team["stats"]["KrTD"]["#text"];
                currentStats.prTd = (string)team["stats"]["PrTD"]["#text"];
                currentStats.fgBlk = (string)team["stats"]["FgBlk"]["#text"];
                currentStats.xpBlk = (string)team["stats"]["XpBlk"]["#text"];
                currentTeam = new Team((string)team["team"]["Abbreviation"]);
                currentDefense = new Defense(currentTeam, currentStats);
                defenses.Add(currentDefense);
            }
            Thread.Sleep(10000);
            return defenses;
        }
    }
}
