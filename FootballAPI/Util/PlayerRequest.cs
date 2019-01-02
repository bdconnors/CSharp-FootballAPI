using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FootballAPI.Util
{
    class PlayerRequest:Request
    {
        public PlayerRequest(string season, bool regularSeason) : base(season, regularSeason)
        { }
        public PlayerRequest(bool regularSeason) : base(regularSeason)
        { }
        /// <summary>
        /// Gets all active player information for a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing the player information of all players of specified position</returns>
        public List<string[]> GetPlayers(string position)
        {
            string PlayersByPosition = "/roster_players.json?rosterstatus=assigned-to-roster&position=" + position;
            List<string[]> players = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(PlayersByPosition).Result)["rosterplayers"]["playerentry"];
            string[] playerInfo;
            foreach (JToken player in allPlayers)
            {
                playerInfo = new string[6];
                if (player["team"] == null) continue;
                playerInfo[0] = (string) player["player"]["ID"];
                playerInfo[1] = (string) player["player"]["FirstName"];
                playerInfo[2] = (string) player["player"]["LastName"];
                playerInfo[3] = (string) player["player"]["JerseyNumber"];
                playerInfo[4] = (string) player["player"]["Position"];
                playerInfo[5] = (string) player["team"]["Abbreviation"];
                players.Add(playerInfo);
            }
            return players;
        }
        /// <summary>
        /// Gets game statistics for players of a specified position on a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing game stats for players of specified position on specified NFL team</returns>
        public List<string[]> GetGameStats(string team, string position)
        {
            string GameStats = "/player_gamelogs.json?team=" + team + "&position=" + position;
            List<string[]> stats = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(GameStats).Result)["rosterplayers"]["playerentry"];
            string[] playerStats;
            foreach (JToken player in allPlayers)
            {
                playerStats = new string[6];
                stats.Add(playerStats);
            }
            return stats;
        }
        /// <summary>
        /// Gets season statistics for all players of a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing season stats of all players of specified position</returns>
        public List<string[]> GetSeasonStats(string position)
        {
            string SeasonStats = "/cumulative_player_stats.json?position=" + position;
            List<string[]> stats = new List<string[]>();
            JArray allPlayers = (JArray)JObject.Parse(Submit(SeasonStats).Result)["rosterplayers"]["playerentry"];
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
