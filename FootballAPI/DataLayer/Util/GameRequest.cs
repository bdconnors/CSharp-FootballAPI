using FootballAPI.DataLayer.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace FootballAPI.DataLayer.Util
{
    public class GameRequest : Request
    {
        public GameRequest(Season season) : base(season)
        { }
        /// <summary>
        /// Gets information for all games played by a specified NFL team
        /// </summary>
        /// <param name="team">Contains specific team abbreviation (i.e. NYG for New York Giants)</param>
        /// <returns>List string[] Containing information for all games played by specified NFL team</returns>
        public List<Game> GetGames()
        {
            List<Team> teams = new TeamRequest(new Season(season.year, season.playoffs)).GetTeams();
            List<Game> games = new List<Game>();
            foreach (Team team in teams)
            {
                Thread.Sleep(10000);
                string TeamGames = "/team_gamelogs.json?team=" + team.abbr;
                JArray allGames = (JArray)JObject.Parse(Submit(TeamGames))["teamgamelogs"]["gamelogs"];
                Game game;
                foreach (JToken gameInfo in allGames)
                {
                    game = new Game();
                    game.game.gameid = (string)gameInfo["game"]["id"];
                    game.game.date = (string)gameInfo["game"]["date"];
                    game.game.time = (string)gameInfo["game"]["time"];
                    game.awayTeam.abbr = (string)gameInfo["game"]["awayTeam"]["Abbreviation"];
                    game.homeTeam.abbr = (string)gameInfo["game"]["homeTeam"]["Abbreviation"];
                    games.Add(game);
                }
            }
            Thread.Sleep(10000);
            return games;
        }
    }
}