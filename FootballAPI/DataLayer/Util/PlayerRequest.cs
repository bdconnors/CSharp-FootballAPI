using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FootballAPI.DataLayer.Models;
using Newtonsoft.Json.Linq;

namespace FootballAPI.DataLayer.Util
{
    public class PlayerRequest:Request
    {
        private string[] positions = new string[] { "QB", "RB", "WR", "TE", "K" };
        public PlayerRequest(Season season) : base(season)
        { }
        /// <summary>
        /// Gets all active player information for a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing the player information of all players of specified position</returns>
        public List<Player> GetPlayers()
        {
            string getPlayers = null;
            List<Player> players = new List<Player>();
            foreach (string position in positions)
            {
                getPlayers= "/roster_players.json?rosterstatus=assigned-to-roster&position=" + position;
                JArray allPlayers = (JArray)JObject.Parse(Submit(getPlayers))["rosterplayers"]["playerentry"];
                Player player;
                foreach (JObject playerInfo in allPlayers)
                {
                    if (playerInfo["team"] == null) continue;
                    player = new Player(new PlayerInfo((string)playerInfo["player"]["ID"]),new Team());
                    player.player.fname = (string)playerInfo["player"]["FirstName"];
                    player.player.lname = (string)playerInfo["player"]["LastName"];
                    player.player.number = (string)playerInfo["player"]["JerseyNumber"];
                    player.player.position = (string)playerInfo["player"]["Position"];
                    player.team.abbr = (string)playerInfo["team"]["Abbreviation"];
                    players.Add(player);
                }
            }
            Thread.Sleep(10000);
            return players;
        }
        /// <summary>
        /// Gets game statistics for players of a specified position on a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing game stats for players of specified position on specified NFL team</returns>
        public List<Player> GetGameStats(string team,string position)
        {        
            List<Player> inDB = GetPlayers();
            List<Player> players = new List<Player>();
            string gameStats = "/player_gamelogs.json?team=" + team + "&position=" + position;
            JArray allPlayers = (JArray)JObject.Parse(Submit(gameStats))["playergamelogs"]["gamelogs"];
            PlayerStats currentStats;
            Game currentGame;      
            PlayerGameStats currentGameStats;
            Player currentPlayer;
            foreach (JObject player in allPlayers)
            {
                currentStats = new PlayerStats();
                currentGame = new Game(new GameInfo((string)player["game"]["id"]));
                currentPlayer = new Player(new PlayerInfo((string)player["player"]["ID"]), new Team(team), new List<PlayerGameStats>());
                if (inDB.Where(p => p.player.playerid == currentPlayer.player.playerid).Any())
                {
                    if (position.Equals("K"))
                    {
                        currentStats.fgAtt = (string)player["stats"]["FgAtt"]["#text"];
                        currentStats.fgMade = (string)player["stats"]["FgMade"]["#text"];
                        currentStats.xpAtt = (string)player["stats"]["XpAtt"]["#text"];
                        currentStats.xpMade = (string)player["stats"]["XpMade"]["#text"];
                        currentStats.fgPct = (string)player["stats"]["FgPct"]["#text"];
                        currentStats.xpPct = (string)player["stats"]["XpPct"]["#text"];
                    }
                    else
                    {
                        currentStats.passAtt = (string)player["stats"]["PassAttempts"]["#text"];
                        currentStats.passComp = (string)player["stats"]["PassCompletions"]["#text"];
                        currentStats.passYds = (string)player["stats"]["PassYards"]["#text"];
                        currentStats.passTds = (string)player["stats"]["PassTD"]["#text"];
                        currentStats.intc = (string)player["stats"]["PassInt"]["#text"];
                        currentStats.rushAtt = (string)player["stats"]["RushAttempts"]["#text"];
                        currentStats.rushYds = (string)player["stats"]["RushYards"]["#text"];
                        currentStats.rushTds = (string)player["stats"]["RushTD"]["#text"];
                        currentStats.fum = (string)player["stats"]["RushFumbles"]["#text"];
                        currentStats.rec = (string)player["stats"]["Receptions"]["#text"];
                        currentStats.recYds = (string)player["stats"]["RecYards"]["#text"];
                        currentStats.recTds = (string)player["stats"]["RecTD"]["#text"];
                    }

                    currentGameStats = new PlayerGameStats(currentGame, currentStats);
                    currentPlayer.gameLogs.Add(currentGameStats);
                    players.Add(currentPlayer);
                }            
            }
            Thread.Sleep(10000);
            return players;
        }
        /// <summary>
        /// Gets season statistics for all players of a specified position
        /// </summary>
        /// <param name="position">Contains specific position abbreviation (i.e. WR for Wide Receiver)</param>
        /// <returns>List of string[] Containing season stats of all players of specified position</returns>
        public List<Player> GetSeasonStats()
        {
            List<Player> players = new List<Player>();
            List<Player> inDB = GetPlayers();

            string seasonStats = null;
            foreach (string position in positions)
            {
                seasonStats = "/cumulative_player_stats.json?position=" + position;
                JArray allPlayers = (JArray)JObject.Parse(Submit(seasonStats))["cumulativeplayerstats"]["playerstatsentry"];
                PlayerStats currentStats;
                Player currentPlayer;
                foreach (JObject player in allPlayers)
                {   
                                    
                    currentPlayer = new Player(new PlayerInfo((string)player["player"]["ID"]),new Team(),new PlayerStats());
                    currentStats = currentPlayer.seasonLog;
                    if (inDB.Where(p => p.player.playerid == currentPlayer.player.playerid).Any())
                    {
                        if (position.Equals("K"))
                        {

                            currentStats.fgAtt = (string)player["stats"]["FgAtt"]["#text"];
                            currentStats.fgMade = (string)player["stats"]["FgMade"]["#text"];
                            currentStats.xpAtt = (string)player["stats"]["XpAtt"]["#text"];
                            currentStats.xpMade = (string)player["stats"]["XpMade"]["#text"];
                            currentStats.fgPct = (string)player["stats"]["FgPct"]["#text"];
                            currentStats.xpPct = (string)player["stats"]["XpPct"]["#text"];
                        }
                        else
                        {
                            currentStats.gamesPlayed = (string)player["stats"]["GamesPlayed"]["#text"];
                            currentStats.passAtt = (string)player["stats"]["PassAttempts"]["#text"];
                            currentStats.passComp = (string)player["stats"]["PassCompletions"]["#text"];
                            currentStats.passYds = (string)player["stats"]["PassYards"]["#text"];
                            currentStats.passTds = (string)player["stats"]["PassTD"]["#text"];
                            currentStats.intc = (string)player["stats"]["PassInt"]["#text"];
                            currentStats.rushAtt = (string)player["stats"]["RushAttempts"]["#text"];
                            currentStats.rushYds = (string)player["stats"]["RushYards"]["#text"];
                            currentStats.rushTds = (string)player["stats"]["RushTD"]["#text"];
                            currentStats.fum = (string)player["stats"]["RushFumbles"]["#text"];
                            currentStats.rec = (string)player["stats"]["Receptions"]["#text"];
                            currentStats.recYds = (string)player["stats"]["RecYards"]["#text"];
                            currentStats.recTds = (string)player["stats"]["RecTD"]["#text"];
                        }
                        players.Add(currentPlayer);
                    }
                }
            }
            Thread.Sleep(10000);
            return players;
        }
    }
}
