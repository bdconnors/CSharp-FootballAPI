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
            try
            {
                string sql = "SELECT gamesplayed,passatt,intc,passcomp,passyds,passtds,rushatt,rushyds,rushtds,fum,rec,"+
                "recyds,rectds,fgatt,fgmade,xpatt,xpmade,fgpct,xppct "+
                "FROM PlayerStats "+
                "INNER JOIN PlayerSeasonStats ON PlayerStats.Statsid = PlayerSeasonStats.Statsid "+
                "INNER JOIN Player ON PlayerSeasonStats.Playerid = Player.PlayerID "+
                "WHERE Player.PlayerID = @Playerid;";
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
                string[] result = db.GetData(sql, values)[0];
                player.seasonLog = new PlayerStats();
                player.seasonLog.gamesPlayed = result[0];
                player.seasonLog.passAtt = result[1];
                player.seasonLog.passComp = result[2];
                player.seasonLog.passYds = result[3];
                player.seasonLog.passTds = result[4];
                player.seasonLog.intc = result[5];
                player.seasonLog.rushAtt = result[6];
                player.seasonLog.rushYds = result[7];
                player.seasonLog.rushTds = result[8];
                player.seasonLog.fum = result[9];
                player.seasonLog.rec = result[10];
                player.seasonLog.recYds = result[11];
                player.seasonLog.recTds = result[12];
                player.seasonLog.fgAtt = result[13];
                player.seasonLog.fgMade = result[14];
                player.seasonLog.xpAtt = result[15];
                player.seasonLog.xpMade = result[16];
                player.seasonLog.fgPct = result[17];
                player.seasonLog.xpPct = result[18];

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
            string sql = "SELECT Game.Gameid,Game.Date,Game.Time,HomeTeam," +
            "(SELECT Team.City FROM Team WHERE Abbr = HomeTeam)AS HomeTeamCity," +
            "(SELECT Team.Name FROM Team WHERE Abbr = HomeTeam)AS HomeTeamName,AwayTeam," +
            "(SELECT Team.City FROM Team WHERE Abbr = AwayTeam)AS AwayTeamCity," +
            "(SELECT Team.Name FROM Team WHERE Abbr = AwayTeam)AS AwayTeamName," +
            "passatt, passcomp, passyds, passtds,intc,rushatt, rushyds, rushtds, fum, rec," +
            "recyds, rectds, fgatt, fgmade, xpatt, xpmade, fgpct, xppct " +
            "FROM PlayerStats " +
            "INNER JOIN PlayerGameStats ON PlayerStats.Statsid = PlayerGameStats.Statsid " +
            "INNER JOIN PlayerGame ON PlayerGameStats.Gameid = PlayerGame.Gameid " +
            "INNER JOIN Game ON PlayerGame.Gameid = Game.Gameid " +
            "INNER JOIN Player ON PlayerGame.Playerid = Player.PlayerID " +
            "INNER JOIN Team ON Player.Team = Team.Abbr " +
            "WHERE Player.PlayerID = @Playerid AND Game.Gameid = @Gameid " +
            "GROUP BY Date;";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid",player.player.playerid);
            values.Add("@Gameid", gameid);
            try
            {
                string[] result = db.GetData(sql, values)[0];
                PlayerGameStats gameStats;           
                gameStats = new PlayerGameStats();
                gameStats.game.game.gameid = result[0];
                gameStats.game.game.date = result[1];
                gameStats.game.game.time = result[2];
                gameStats.game.homeTeam.abbr = result[3];
                gameStats.game.homeTeam.city = result[4];
                gameStats.game.homeTeam.name = result[5];
                gameStats.game.awayTeam.abbr = result[6];
                gameStats.game.awayTeam.city = result[7];
                gameStats.game.awayTeam.name = result[8];
                gameStats.stats.passAtt = result[9];
                gameStats.stats.passComp = result[10];
                gameStats.stats.passYds = result[11];
                gameStats.stats.passTds = result[12];
                gameStats.stats.intc = result[13];
                gameStats.stats.rushAtt = result[14];
                gameStats.stats.rushYds = result[15];
                gameStats.stats.rushTds = result[16];
                gameStats.stats.fum = result[17];
                gameStats.stats.rec = result[18];
                gameStats.stats.recYds = result[19];
                gameStats.stats.recTds = result[20];
                gameStats.stats.fgAtt = result[21];
                gameStats.stats.fgMade = result[22];
                gameStats.stats.xpAtt = result[23];
                gameStats.stats.xpMade = result[24];
                gameStats.stats.fgPct = result[25];
                gameStats.stats.xpPct = result[26];
                player.gameLogs.Add(gameStats);          
            }
            catch (Exception e)
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
            string sql = "SELECT Game.Gameid,Game.Date,Game.Time,HomeTeam," +
            "(SELECT Team.City FROM Team WHERE Abbr = HomeTeam)AS HomeTeamCity," +
            "(SELECT Team.Name FROM Team WHERE Abbr = HomeTeam)AS HomeTeamName,AwayTeam," +
            "(SELECT Team.City FROM Team WHERE Abbr = AwayTeam)AS AwayTeamCity," +
            "(SELECT Team.Name FROM Team WHERE Abbr = AwayTeam)AS AwayTeamName," +
            "passatt, passcomp, passyds, passtds,intc,rushatt, rushyds, rushtds, fum, rec," +
            "recyds, rectds, fgatt, fgmade, xpatt, xpmade, fgpct, xppct " +
            "FROM PlayerStats " +
            "INNER JOIN PlayerGameStats ON PlayerStats.Statsid = PlayerGameStats.Statsid " +
            "INNER JOIN PlayerGame ON PlayerGameStats.Gameid = PlayerGame.Gameid " +
            "INNER JOIN Game ON PlayerGame.Gameid = Game.Gameid " +
            "INNER JOIN Player ON PlayerGame.Playerid = Player.PlayerID " +
            "INNER JOIN Team ON Player.Team = Team.Abbr " +
            "WHERE Player.PlayerID = @Playerid " +
            "GROUP BY Date;";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
            try
            {               
                List<string[]> queryResults = db.GetData(sql, values);
                PlayerGameStats gameStats;
                foreach (string[] result in queryResults)
                {
                    gameStats = new PlayerGameStats();
                    gameStats.game.game.gameid = result[0];
                    gameStats.game.game.date = result[1];
                    gameStats.game.game.time = result[2];
                    gameStats.game.homeTeam.abbr = result[3];
                    gameStats.game.homeTeam.city = result[4];
                    gameStats.game.homeTeam.name = result[5];
                    gameStats.game.awayTeam.abbr = result[6];
                    gameStats.game.awayTeam.city = result[7];
                    gameStats.game.awayTeam.name = result[8];
                    gameStats.stats.passAtt = result[9];
                    gameStats.stats.passComp = result[10];
                    gameStats.stats.passYds = result[11];
                    gameStats.stats.passTds = result[12];
                    gameStats.stats.intc = result[13];
                    gameStats.stats.rushAtt = result[14];
                    gameStats.stats.rushYds = result[15];
                    gameStats.stats.rushTds = result[16];
                    gameStats.stats.fum = result[17];
                    gameStats.stats.rec = result[18];
                    gameStats.stats.recYds = result[19];
                    gameStats.stats.recTds = result[20];
                    gameStats.stats.fgAtt= result[21];
                    gameStats.stats.fgMade= result[22];
                    gameStats.stats.xpAtt = result[23];
                    gameStats.stats.xpMade = result[24];
                    gameStats.stats.fgPct = result[25];
                    gameStats.stats.xpPct = result[26];
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
            db.StartTransaction();
            foreach (PlayerGameStats gameStats in player.gameLogs)
            {
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.player.playerid);
                values.Add("@Gameid",gameStats.game.game.gameid);
                effected += db.SetData(sql1, values);
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
                effected += db.SetData(sql2, values);
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.player.playerid);
                values.Add("@Gameid", gameStats.game.game.gameid);
                effected += db.SetData(sql3, values);
            }
            db.EndTransaction();
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