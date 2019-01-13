using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerSeasonService : Database
    {

        public void Get(PlayerSeasonLogs players)
        {
            try
            {
                List<string[]> results = SelectProc("GetAllPlayerSeasonLogs", null);
                Player player;
                foreach (string[] result in results)
                {
                    player = new Player();
                    player.seasonLog = new PlayerStats();
                    player.player.playerid = result[0];
                    player.player.fname = result[1];
                    player.player.lname = result[2];
                    player.player.number = result[3];
                    player.player.position = result[4];
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
                    players.playerseasonlogs.Add(player);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(PlayerSeasonLogs players,string position)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@pos", position } };
                List<string[]> results = SelectProc("GetPlayerSeasonLogByPos", values);
                Player player;
                foreach (string[] result in results)
                {
                    player = new Player();
                    player.seasonLog = new PlayerStats();
                    player.player.playerid = result[0];
                    player.player.fname = result[1];
                    player.player.lname = result[2];
                    player.player.number = result[3];
                    player.player.position = result[4];
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
                    players.playerseasonlogs.Add(player);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(Player player)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
                string[] result = SelectProc("GetPlayerSeasonLog", values)[0];
                player.seasonLog = new PlayerStats();
                player.player.playerid = result[0];
                player.player.fname = result[1];
                player.player.lname = result[2];
                player.player.number = result[3];
                player.player.position = result[4];
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
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Insert(Player player)
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Playerid", player.player.playerid);
                values.Add("@passatt", player.seasonLog.passAtt);
                values.Add("@passcomp", player.seasonLog.passComp);
                values.Add("@passyds", player.seasonLog.passYds);
                values.Add("@passtds", player.seasonLog.passTds);
                values.Add("@intc", player.seasonLog.intc);
                values.Add("@rushatt", player.seasonLog.rushAtt);
                values.Add("@rushyds", player.seasonLog.rushYds);
                values.Add("@rushtds", player.seasonLog.rushTds);
                values.Add("@fum", player.seasonLog.fum);
                values.Add("@rec", player.seasonLog.rec);
                values.Add("@recyds", player.seasonLog.recYds);
                values.Add("@rectds", player.seasonLog.recTds);
                values.Add("@fgatt", player.seasonLog.fgAtt);
                values.Add("@fgmade", player.seasonLog.fgMade);
                values.Add("@xpatt", player.seasonLog.xpAtt);
                values.Add("@xpmade", player.seasonLog.xpMade);
                values.Add("@fgpct", player.seasonLog.fgPct);
                values.Add("@xppct", player.seasonLog.fgMade);
                effected += UpdateProc("InsertPlayerSeasonLog", values);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}