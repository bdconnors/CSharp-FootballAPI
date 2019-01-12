using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerService : Database
    {
        public Player player { get; set; }

        public PlayerService(Player player)
        {
            this.player = player;
        }
        public PlayerService()
        {
        }
        
        public void GetSeasonLog()
        {    
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.playerid } };
                string[] result = SelectProc("GetPlayerSeasonLog", values)[0];
                player.seasonLog = new PlayerStats();
                player.playerid = result[0];
                player.fname = result[1];
                player.lname = result[2];
                player.number = result[3];
                player.position = result[4];
                player.team.abbr = result[5];
                player.team.city = result[6];
                player.team.name = result[7];
                player.seasonLog.gamesPlayed = result[8];
                player.seasonLog.passAtt = result[9];
                player.seasonLog.passComp = result[10];
                player.seasonLog.passYds = result[11];
                player.seasonLog.passTds = result[12];
                player.seasonLog.intc = result[13];
                player.seasonLog.rushAtt = result[14];
                player.seasonLog.rushYds = result[15];
                player.seasonLog.rushTds = result[16];
                player.seasonLog.fum = result[17];
                player.seasonLog.rec = result[18];
                player.seasonLog.recYds = result[19];
                player.seasonLog.recTds = result[20];
                player.seasonLog.fgAtt = result[21];
                player.seasonLog.fgMade = result[22];
                player.seasonLog.xpAtt = result[23];
                player.seasonLog.xpMade = result[24];
                player.seasonLog.fgPct = result[25];
                player.seasonLog.xpPct = result[26];

            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGame(string gameid)
        {
            if (player.gameLogs == null)
            {
                player.gameLogs = new List<PlayerGameStats>();
            }
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid",player.playerid);
            values.Add("@Gameid", gameid);
            try
            {
                string[] result = SelectProc("GetPlayerGameStats", values)[0];
                PlayerGameStats gameStats = new PlayerGameStats();
                player.playerid = result[0];
                player.fname = result[1];
                player.lname = result[2];
                player.number = result[3];
                player.position = result[4];
                player.team.abbr = result[5];
                player.team.city = result[6];
                player.team.name = result[7];
                gameStats.game.gameid = result[8];
                gameStats.game.date = result[9];
                gameStats.game.time = result[10];
                gameStats.game.homeTeam.abbr = result[11];
                gameStats.game.homeTeam.city = result[12];
                gameStats.game.homeTeam.name = result[13];
                gameStats.game.awayTeam.abbr = result[14];
                gameStats.game.awayTeam.city = result[15];
                gameStats.game.awayTeam.name = result[16];
                gameStats.stats.passAtt = result[17];
                gameStats.stats.passComp = result[18];
                gameStats.stats.passYds = result[19];
                gameStats.stats.passTds = result[20];
                gameStats.stats.intc = result[21];
                gameStats.stats.rushAtt = result[22];
                gameStats.stats.rushYds = result[23];
                gameStats.stats.rushTds = result[24];
                gameStats.stats.fum = result[25];
                gameStats.stats.rec = result[26];
                gameStats.stats.recYds = result[27];
                gameStats.stats.recTds = result[28];
                gameStats.stats.fgAtt = result[29];
                gameStats.stats.fgMade = result[30];
                gameStats.stats.xpAtt = result[31];
                gameStats.stats.xpMade = result[32];
                gameStats.stats.fgPct = result[33];
                gameStats.stats.xpPct = result[34];
                player.gameLogs.Add(gameStats);              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGameLogs()
        {
          
           
            try
            {
               

                Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.playerid } };
                List<string[]> results = SelectProc("GetPlayerGameLogs", values);
                player.gameLogs = new List<PlayerGameStats>();
                player.playerid = results[0][0];
                player.fname = results[0][1];
                player.lname = results[0][2];
                player.number = results[0][3];
                player.position = results[0][4];
                player.team.abbr = results[0][5];
                player.team.city = results[0][6];
                player.team.name = results[0][7];
                PlayerGameStats gameStats;
                foreach (string[] result in results)
                {
                    gameStats = new PlayerGameStats();
                    gameStats.game.gameid = result[8];
                    gameStats.game.date = result[9];
                    gameStats.game.time = result[10];
                    gameStats.game.homeTeam.abbr = result[11];
                    gameStats.game.homeTeam.city = result[12];
                    gameStats.game.homeTeam.name = result[13];
                    gameStats.game.awayTeam.abbr = result[14];
                    gameStats.game.awayTeam.city = result[15];
                    gameStats.game.awayTeam.name = result[16];
                    gameStats.stats.passAtt = result[17];
                    gameStats.stats.passComp = result[18];
                    gameStats.stats.passYds = result[19];
                    gameStats.stats.passTds = result[20];
                    gameStats.stats.intc = result[21];
                    gameStats.stats.rushAtt = result[22];
                    gameStats.stats.rushYds = result[23];
                    gameStats.stats.rushTds = result[24];
                    gameStats.stats.fum = result[25];
                    gameStats.stats.rec = result[26];
                    gameStats.stats.recYds = result[27];
                    gameStats.stats.recTds = result[28];
                    gameStats.stats.fgAtt= result[29];
                    gameStats.stats.fgMade= result[30];
                    gameStats.stats.xpAtt = result[31];
                    gameStats.stats.xpMade = result[32];
                    gameStats.stats.fgPct = result[33];
                    gameStats.stats.xpPct = result[34];
                    player.gameLogs.Add(gameStats);
               }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int PostGameLogs()
        {
            int effected = 0;
            string sql1 = "INSERT INTO PlayerGame(Playerid,Gameid)VALUES(@Playerid,@Gameid)";
            string sql2 = "INSERT INTO PlayerStats(passatt, passcomp, passyds, passtds,intc,rushatt, rushyds,"+
                "rushtds, fum, rec,recyds, rectds, fgatt, fgmade, xpatt, xpmade, fgpct, xppct)VALUES(@passatt, @passcomp, " +
                "@passyds, @passtds,@intc,@rushatt, @rushyds, @rushtds, @fum, @rec,@recyds, @rectds, @fgatt, @fgmade, @xpatt, @xpmade, @fgpct, @xppct)";
            string sql3 = "INSERT INTO PlayerGameStats(Playerid,Gameid,Statsid)VALUES(@Playerid,@Gameid,last_insert_id());";
            Dictionary<string, string> values;
            foreach (PlayerGameStats gameStats in player.gameLogs)
            {
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.playerid);
                values.Add("@Gameid",gameStats.game.gameid);
                effected += UpdateStmt(sql1, values);
                values = new Dictionary<string, string>();
                values.Add("@passatt",gameStats.stats.passAtt);
                values.Add("@passcomp",gameStats.stats.passComp);
                values.Add("@passyds",gameStats.stats.passYds);
                values.Add("@passtds",gameStats.stats.passTds);
                values.Add("@intc",gameStats.stats.intc);
                values.Add("@rushatt",gameStats.stats.rushAtt);
                values.Add("@rushyds", gameStats.stats.rushYds);
                values.Add("@rushtds", gameStats.stats.rushTds);
                values.Add("@fum", gameStats.stats.fum);
                values.Add("@rec", gameStats.stats.rec);
                values.Add("@recyds", gameStats.stats.recYds);
                values.Add("@rectds", gameStats.stats.recTds);
                values.Add("@fgatt", gameStats.stats.fgAtt);
                values.Add("@fgmade", gameStats.stats.fgMade);
                values.Add("@xpatt", gameStats.stats.xpAtt);
                values.Add("@xpmade", gameStats.stats.xpMade);
                values.Add("@fgpct", gameStats.stats.fgPct);
                values.Add("@xppct", gameStats.stats.fgMade);
                effected += UpdateStmt(sql2, values);
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.playerid);
                values.Add("@Gameid", gameStats.game.gameid);
                effected += UpdateStmt(sql3, values);
            }
            return effected;
        }
        public bool Exists()
        {
            string sql = "SELECT * FROM Player WHERE PlayerID = @Playerid";
            int record;
            bool exists = false;
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.playerid } };
            try
            {
                record = SelectStmt(sql, values).Count;
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