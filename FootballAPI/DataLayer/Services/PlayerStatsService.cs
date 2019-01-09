using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerStatsService
    {
        public PlayerStats stats { get; set; }
        public Player player { get; set; }
        private static Database db;
        public PlayerStatsService(Player player,PlayerStats stats)
        {
            this.player = player;
            this.stats = stats;
            db = new Database();
        }
        public PlayerStatsService(Player player)
        {
            this.player = player;
            db = new Database();
        }
        public PlayerStatsService()
        {
            db = new Database();
        }

        public void Fetch()
        {
            string sql = "SELECT gamesplayed,passatt,passcomp,passyds,passtds," +
            "intc,rushatt,rushyds,rushtds,fum,rec,recyds,rectds," +
            "fgatt,fgmade,xpatt,xpmade,fgpct,xppct FROM PlayerStats " +
            "INNER JOIN PlayerSeasonStats ON PlayerStats.statsid = PlayerSeasonStats.statsid " +
            "INNER JOIN Player ON PlayerSeasonStats.Playerid = Player.PlayerID " +
            "WHERE Player.PlayerID = @PlayerID;";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
            try
            {
                string[] queryResult = db.GetData(sql, values)[0];
                stats.gamesPlayed = queryResult[0];
                stats.passAtt = queryResult[1];
                stats.passComp = queryResult[2];
                stats.passYds = queryResult[3];
                stats.passTds = queryResult[4];
                stats.intc = queryResult[5];
                stats.rushAtt = queryResult[6];
                stats.rushYds = queryResult[7];
                stats.rushTds = queryResult[8];
                stats.fum = queryResult[9];
                stats.rec = queryResult[10];
                stats.recYds = queryResult[11];
                stats.recTds = queryResult[12];
                stats.fgAtt = queryResult[13];
                stats.fgMade = queryResult[14];
                stats.xpAtt = queryResult[15];
                stats.xpMade = queryResult[16];
                stats.fgPct = queryResult[17];
                stats.xpPct = queryResult[18];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Post()
        {
            stats = player.seasonLog;
            int effected = 0;
            Dictionary<string, string> values = new Dictionary<string, string>();
            string sql1 = "INSERT INTO PlayerStats(gamesplayed,passatt,passcomp,passyds,passtds,intc," +
            "rushatt,rushyds,rushtds,fum,rec,recyds,rectds,fgatt,fgmade,xpatt,xpmade,fgpct,xppct)" +
            "VALUES(@gamesplayed,@passatt,@passcomp,@passyds,@passtds,@intc,@rushatt,@rushyds,@rushtds," +
            "@fum,@rec,@recyds,@rectds,@fgatt,@fgmade,@xpatt,@xpmade,@fgpct,@xppct)";
            string sql2 = "INSERT INTO PlayerSeasonStats(Playerid,Statsid)VALUES(@Playerid,last_insert_id())";
            values.Add("@gamesplayed",player.seasonLog.gamesPlayed); values.Add("@passatt", player.seasonLog.passAtt);
            values.Add("@passcomp", player.seasonLog.passComp); values.Add("@passyds", player.seasonLog.passYds);
            values.Add("@passtds", player.seasonLog.passTds); values.Add("@intc", player.seasonLog.intc);
            values.Add("@rushatt", player.seasonLog.rushAtt); values.Add("@rushyds", player.seasonLog.rushYds);
            values.Add("@rushtds", player.seasonLog.rushTds); values.Add("@fum", player.seasonLog.fum);
            values.Add("@rec", player.seasonLog.rec); values.Add("@recyds", player.seasonLog.recYds);
            values.Add("@rectds", player.seasonLog.recTds); values.Add("@fgatt", player.seasonLog.fgAtt);
            values.Add("@fgmade", player.seasonLog.fgMade);values.Add("@xpatt", player.seasonLog.xpAtt);
            values.Add("@xpmade", player.seasonLog.xpMade);values.Add("@fgpct", player.seasonLog.fgPct);
            values.Add("@xppct", player.seasonLog.xpPct);
            try
            {
                db.StartTransaction();
                effected += db.SetData(sql1, values);
                values = new Dictionary<string, string>();
                values.Add("@Playerid", player.player.playerid);
                effected += db.SetData(sql2, values);
                db.EndTransaction();
            }
            catch(Exception e)
            {
                db.RollbackTransaction();
                effected = -1;
                throw new Exception(e.Message, e);
                
            }
            return effected;
        }
    }
}