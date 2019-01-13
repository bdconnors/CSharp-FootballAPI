using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerGameService : Database
    {
        public void Get(Player player, string gameid)
        {
            if (player.gameLogs == null)
            {
                player.gameLogs = new List<PlayerGameStats>();
            }
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid", player.player.playerid);
            values.Add("@Gameid", gameid);
            try
            {
                string[] result = SelectProc("GetPlayerGameStats", values)[0];
                PlayerGameStats gameStats = new PlayerGameStats();
                player.player.playerid = result[0];
                player.player.fname = result[1];
                player.player.lname = result[2];
                player.player.number = result[3];
                player.player.position = result[4];
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
        public void Get(Player player)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
                List<string[]> results = SelectProc("GetPlayerGameLogs", values);
                player.gameLogs = new List<PlayerGameStats>();
                player.player.playerid = results[0][0];
                player.player.fname = results[0][1];
                player.player.lname = results[0][2];
                player.player.number = results[0][3];
                player.player.position = results[0][4];
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
                    gameStats.stats.fgAtt = result[29];
                    gameStats.stats.fgMade = result[30];
                    gameStats.stats.xpAtt = result[31];
                    gameStats.stats.xpMade = result[32];
                    gameStats.stats.fgPct = result[33];
                    gameStats.stats.xpPct = result[34];
                    player.gameLogs.Add(gameStats);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(PlayerGameLogs players,string gameid)
        {
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@game", gameid } };
            List<string[]> results = SelectProc("GetAllPlayerGameStats", values);
            Player player = null;
            PlayerGameStats gameStats = null;
            foreach (string[] result in results)
            {
                if (player == null || player.player.playerid != result[0])
                {
                    if (player != null)
                    {
                        players.playergamelogs.Add(player);
                    }
                    player = new Player();
                    player.gameLogs = new List<PlayerGameStats>();
                    player.player.playerid = result[0];
                    player.player.fname = result[1];
                    player.player.lname = result[2];
                    player.player.number = result[3];
                    player.player.position = result[4];
                    player.team.abbr = result[5];
                    player.team.city = result[6];
                    player.team.name = result[7];

                }
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
                gameStats.stats.fgAtt = result[29];
                gameStats.stats.fgMade = result[30];
                gameStats.stats.xpAtt = result[31];
                gameStats.stats.xpMade = result[32];
                gameStats.stats.fgPct = result[33];
                gameStats.stats.xpPct = result[34];
                player.gameLogs.Add(gameStats);
            }
        }
        public int Insert(Player player)
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values;
                foreach (PlayerGameStats gameStats in player.gameLogs)
                {
                    values = new Dictionary<string, string>();
                    values.Add("@Playerid", player.player.playerid);
                    values.Add("@Gameid", gameStats.game.gameid);
                    values.Add("@passatt", gameStats.stats.passAtt);
                    values.Add("@passcomp", gameStats.stats.passComp);
                    values.Add("@passyds", gameStats.stats.passYds);
                    values.Add("@passtds", gameStats.stats.passTds);
                    values.Add("@intc", gameStats.stats.intc);
                    values.Add("@rushatt", gameStats.stats.rushAtt);
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
                    effected += UpdateProc("InsertPlayerGameLogs", values);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}