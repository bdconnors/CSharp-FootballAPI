using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerService
    {
        public Player player { get; set; }
        private PlayerGameStatsService gameStatsService;
        private PlayerStatsService statsService;
        private static Database db;

        public PlayerService(Player player)
        {
            this.player = player;
            db = new Database();
        }
        public PlayerService()
        {
            db = new Database();
        }

        public void Fetch()
        {
            try
            {
                GetInfo();
                GetSeasonLog();
                GetGameLogs();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetInfo()
        {
            if(player.team == null)
            {
                player.team = new Team();
            }
            string sql = "SELECT Playerid,fname,lname,number,position,team,City,Name FROM Player "+
            "INNER JOIN Team ON Player.team = Team.abbr WHERE PlayerID = @PlayerID; ";
            Dictionary<string, string> values = new Dictionary<string, string>(){ { "@PlayerID", player.player.playerid } };
            try
            {
                string[] queryResult = db.GetData(sql, values)[0];
                player.player.playerid = queryResult[0];
                player.player.fname = queryResult[1];
                player.player.lname = queryResult[2];
                player.player.number = queryResult[3];
                player.player.position = queryResult[4];
                player.team.abbr = queryResult[5];
                player.team.city = queryResult[6];
                player.team.name = queryResult[7];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetSeasonLog()
        {    
            statsService = new PlayerStatsService(player,new PlayerStats());
            try
            {
                statsService.Fetch();
                player.seasonLog = statsService.stats;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGame(string gameid)
        {
            gameStatsService = new PlayerGameStatsService(player, new PlayerGameStats(new Game(new GameInfo(gameid))));
            try
            {   
                if(player.gameLogs == null)
                {
                    player.gameLogs = new List<PlayerGameStats>();
                }
                gameStatsService.Fetch();
                player.gameLogs.Add(gameStatsService.gameStats);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGameLogs()
        {
            if (player.gameLogs == null)
            {
                player.gameLogs = new List<PlayerGameStats>();
            }
            string sql = "SELECT Gameid FROM PlayerGameStats WHERE Playerid = @PlayerID";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
            try
            {               
                List<string[]> queryResults = db.GetData(sql, values);
                foreach (string[] result in queryResults)
                {
                    GetGame(result[0]);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int PostSeasonLog()
        {
            int effected = 0;
            statsService = new PlayerStatsService(player);
            try
            {
                effected += statsService.Post();
            }
            catch(Exception e)
            {
                effected = -1;
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        public int PostGameLogs()
        {
            int effected = 0;
            List<PlayerGameStats> gameLogs = player.gameLogs;
            gameStatsService = new PlayerGameStatsService(player);
            try
            {
                foreach (PlayerGameStats game in gameLogs)
                {
                    gameStatsService.gameStats = game;
                    effected += gameStatsService.Post();
                }
            }
            catch(Exception e)
            {
                effected = -1;
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        public bool Exists()
        {
            string sql = "SELECT * FROM Player WHERE PlayerID = @Playerid";
            int record;
            bool exists = false;
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
            try
            {
                record = db.GetData(sql, values).Count;
                if(record == 0)
                {
                    exists = false;
                }
                else
                {
                    exists = true;
                }
            }
            catch(Exception e)
            {           
                throw new Exception(e.Message, e);
            }
            return exists;
        }
    }
}