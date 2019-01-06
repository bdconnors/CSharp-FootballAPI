using System.Collections.Generic;
using FootballAPI.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    public class PlayerRequest:Request
    {
        public PlayerRequest(Season season) : base(season)
        { }
        /// <summary>
        /// Gets all active player information for a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing the player information of all players of specified position</returns>
        public List<Player> GetPlayers()
        {      
            List<Player> players = new List<Player>();
            string[] positions = new string[] { "QB", "RB", "WR", "TE", "K" };
            foreach (string position in positions)
            {
                string getPlayers= "/roster_players.json?rosterstatus=assigned-to-roster&position=" + position;
                JArray allPlayers = (JArray)JObject.Parse(Submit(getPlayers))["rosterplayers"]["playerentry"];
                Player player;
                foreach (JToken playerInfo in allPlayers)
                {
                    player = new Player();
                    if (playerInfo["team"] == null) continue;
                    player.playerid = (string)playerInfo["player"]["ID"];
                    player.fname = (string)playerInfo["player"]["FirstName"];
                    player.lname = (string)playerInfo["player"]["LastName"];
                    player.number = (string)playerInfo["player"]["JerseyNumber"];
                    player.position = (string)playerInfo["player"]["Position"];
                    player.team = (string)playerInfo["team"]["Abbreviation"];
                    players.Add(player);
                }
            }
            return players;
        }
        /// <summary>
        /// Gets game statistics for players of a specified position on a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing game stats for players of specified position on specified NFL team</returns>
        public List<PlayerGameStats> GetGameStats(string team, string position)
        {
            string GameStats = "/player_gamelogs.json?team=" + team + "&position=" + position;
            List<PlayerGameStats> stats = new List<PlayerGameStats>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(GameStats))["playergamelogs"]["gamelogs"];
            PlayerGameStats playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new PlayerGameStats();
                playerStats.playerid = (string)player["player"]["ID"];
                playerStats.gameid = (string)player["game"]["id"];
                playerStats.passAtt = (string)player["stats"]["PassAttempts"]["#text"];
                playerStats.passComp = (string)player["stats"]["PassCompletions"]["#text"];
                playerStats.passYds = (string)player["stats"]["PassYards"]["#text"];
                playerStats.passTds = (string)player["stats"]["PassTD"]["#text"];
                playerStats.intc = (string)player["stats"]["PassInt"]["#text"];
                playerStats.rushAtt = (string)player["stats"]["RushAttempts"]["#text"];
                playerStats.rushYds = (string)player["stats"]["RushYards"]["#text"];
                playerStats.rushTds = (string)player["stats"]["RushTD"]["#text"];
                playerStats.fum = (string)player["stats"]["RushFumbles"]["#text"];
                playerStats.rec = (string)player["stats"]["Receptions"]["#text"];
                playerStats.recYds = (string)player["stats"]["RecYards"]["#text"];
                playerStats.recTds = (string)player["stats"]["RecTD"]["#text"];
                playerStats.fgAtt = (string)player["stats"]["FgAtt"]["#text"];
                playerStats.fgMade= (string)player["stats"]["stats"]["FgMade"]["#text"];
                playerStats.xpAtt = (string)player["stats"]["XpAtt"]["#text"];
                playerStats.xpMade = (string)player["stats"]["XpMade"]["#text"];
                playerStats.fgPct = (string)player["stats"]["FgPct"]["#text"];
                playerStats.xpPct= (string)player["stats"]["XpPct"]["#text"];
                stats.Add(playerStats);
            }
            return stats;
        }
        /// <summary>
        /// Gets season statistics for all players of a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing season stats of all players of specified position</returns>
        public List<PlayerSeasonStats> GetSeasonStats(string position)
        {
            string SeasonStats = "/cumulative_player_stats.json?position=" + position;
            List<PlayerSeasonStats> stats = new List<PlayerSeasonStats>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(SeasonStats))["cumulativeplayerstats"]["playerstatsentry"];
            PlayerSeasonStats playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new PlayerSeasonStats();
                playerStats.playerid = (string)player["player"]["ID"];
                playerStats.gamesPlayed = (string)player["stats"]["GamesPlayed"]["#text"];
                playerStats.passAtt = (string)player["stats"]["PassAttempts"]["#text"];
                playerStats.passComp = (string)player["stats"]["PassCompletions"]["#text"];
                playerStats.passYds = (string)player["stats"]["PassYards"]["#text"];
                playerStats.passTds = (string)player["stats"]["PassTD"]["#text"];
                playerStats.intc = (string)player["stats"]["PassInt"]["#text"];
                playerStats.rushAtt = (string)player["stats"]["RushAttempts"]["#text"];
                playerStats.rushYds = (string)player["stats"]["RushYards"]["#text"];
                playerStats.rushTds = (string)player["stats"]["RushTD"]["#text"];
                playerStats.fum = (string)player["stats"]["RushFumbles"]["#text"];
                playerStats.rec = (string)player["stats"]["Receptions"]["#text"];
                playerStats.recYds = (string)player["stats"]["RecYards"]["#text"];
                playerStats.recTds = (string)player["stats"]["RecTD"]["#text"];
                playerStats.fgAtt = (string)player["stats"]["FgAtt"]["#text"];
                playerStats.fgMade = (string)player["stats"]["stats"]["FgMade"]["#text"];
                playerStats.xpAtt = (string)player["stats"]["XpAtt"]["#text"];
                playerStats.xpMade = (string)player["stats"]["XpMade"]["#text"];
                playerStats.fgPct = (string)player["stats"]["FgPct"]["#text"];
                playerStats.xpPct= (string)player["stats"]["XpPct"]["#text"];
                stats.Add(playerStats);
                stats.Add(playerStats);
            }
            return stats;
        }
    }
}
