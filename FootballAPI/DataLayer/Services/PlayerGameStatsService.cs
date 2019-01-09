using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerGameStatsService
    {
        public Player player { get; set; }
        public PlayerGameStats gameStats{get; set;}
        private static Database db;

        public PlayerGameStatsService(Player player,PlayerGameStats gameStats)
        {
            this.player = player;
            this.gameStats = gameStats;
            db = new Database();
        }
        public PlayerGameStatsService(Player player)
        {
            this.player = player;
            db = new Database();
        }
        public PlayerGameStatsService()
        {
            db = new Database();
        }
        public void Fetch()
        {   
            string sql = "SELECT PlayerGame.gameid,passatt,passcomp,passyds,passtds," +
            "intc,rushatt,rushyds,rushtds,fum,rec,recyds,rectds," +
            "fgatt,fgmade,xpatt,xpmade,fgpct,xppct FROM PlayerStats " +
            "INNER JOIN PlayerGameStats ON PlayerStats.statsid = PlayerGameStats.Statsid " +
            "INNER JOIN PlayerGame ON PlayerGameStats.Gameid = PlayerGame.Gameid " +
            "INNER JOIN Player ON PlayerGame.Playerid = Player.PlayerID " +
            "WHERE PlayerGame.PlayerID = @PlayerID AND PlayerGame.Gameid = @GameID;";
            Dictionary<string, string> values = new Dictionary<string, string>();
            try
            {
                values.Add("@PlayerID", player.player.playerid);
                values.Add("@GameID", gameStats.game.game.gameid);
                string[] queryResult = db.GetData(sql, values)[0];
                gameStats.game.game.gameid = queryResult[0];
                gameStats.stats.passAtt = queryResult[1];
                gameStats.stats.passComp = queryResult[2];
                gameStats.stats.passYds = queryResult[3];
                gameStats.stats.passTds = queryResult[4];
                gameStats.stats.intc = queryResult[5];
                gameStats.stats.rushAtt = queryResult[6];
                gameStats.stats.rushYds = queryResult[7];
                gameStats.stats.rushTds = queryResult[8];
                gameStats.stats.fum = queryResult[9];
                gameStats.stats.rec = queryResult[10];
                gameStats.stats.recYds = queryResult[11];
                gameStats.stats.recTds = queryResult[12];
                gameStats.stats.fgAtt = queryResult[13];
                gameStats.stats.fgMade = queryResult[14];
                gameStats.stats.xpAtt = queryResult[15];
                gameStats.stats.xpMade = queryResult[16];
                gameStats.stats.fgPct = queryResult[17];
                gameStats.stats.xpPct = queryResult[18];
                GameService gameService = new GameService(gameStats.game);
                gameService.GetInfo();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Post()
        {
            int effected = 0;
            Dictionary<string, string> values = new Dictionary<string, string>();
            string sql1 = "INSERT INTO PlayerGame(Playerid,Gameid)VALUES(@Playerid,@Gameid)";
            string sql2 = "INSERT INTO PlayerStats(passatt,passcomp,passyds,passtds,intc," +
            "rushatt,rushyds,rushtds,fum,rec,recyds,rectds,fgatt,fgmade,xpatt,xpmade,fgpct,xppct)" +
            "VALUES(@passatt,@passcomp,@passyds,@passtds,@intc,@rushatt,@rushyds,@rushtds," +
            "@fum,@rec,@recyds,@rectds,@fgatt,@fgmade,@xpatt,@xpmade,@fgpct,@xppct)";
            string sql3 = "INSERT INTO PlayerGameStats(Playerid,Gameid,Statsid)VALUES(@Playerid,@Gameid,last_insert_id())";       
            try
            {
                db.StartTransaction();
                values.Add("@Playerid", player.player.playerid);
                values.Add("@Gameid", gameStats.game.game.gameid);
                effected += db.SetData(sql1, values);
                values = new Dictionary<string, string>();
                values.Add("@gamesplayed", gameStats.stats.gamesPlayed); values.Add("@passatt", gameStats.stats.passAtt);
                values.Add("@passcomp", gameStats.stats.passComp); values.Add("@passyds", gameStats.stats.passYds);
                values.Add("@passtds", gameStats.stats.passTds); values.Add("@intc", gameStats.stats.intc);
                values.Add("@rushatt", gameStats.stats.rushAtt); values.Add("@rushyds", gameStats.stats.rushYds);
                values.Add("@rushtds", gameStats.stats.rushTds); values.Add("@fum", gameStats.stats.fum);
                values.Add("@rec", gameStats.stats.rec); values.Add("@recyds", gameStats.stats.recYds);
                values.Add("@rectds", gameStats.stats.recTds);values.Add("@fgatt", gameStats.stats.fgAtt);
                values.Add("@fgmade", gameStats.stats.fgMade);values.Add("@xpatt", gameStats.stats.xpAtt);
                values.Add("@xpmade", gameStats.stats.xpMade);values.Add("@fgpct", gameStats.stats.fgPct);
                values.Add("@xppct", gameStats.stats.xpPct);
                effected += db.SetData(sql2, values);
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.player.playerid);
                values.Add("@Gameid", gameStats.game.game.gameid);
                effected += db.SetData(sql3, values);
                db.EndTransaction();
            }
            catch (Exception e)
            {
                db.RollbackTransaction();
                effected = -1;
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}