using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class DefenseService : Database
    {
        public Defense defense { get; set; }
        
        public DefenseService(Defense defense)
        {
            this.defense = defense;
        }
        public DefenseService()
        {

        }
        public void GetSeasonLog()
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@Team", defense.team.abbr } };
                string[] result = SelectProc("GetDefenseSeasonStats", values)[0];
                defense.seasonLog = new DefenseStats();
                defense.team.abbr = result[0];
                defense.team.city = result[1];
                defense.team.name = result[2];
                defense.seasonLog.pa = result[3];
                defense.seasonLog.sck = result[4];
                defense.seasonLog.fum = result[5];
                defense.seasonLog.intc = result[6];
                defense.seasonLog.intTd = result[7];
                defense.seasonLog.fumTd = result[8];
                defense.seasonLog.sfty = result[9];
                defense.seasonLog.krTd = result[10];
                defense.seasonLog.prTd = result[11];
                defense.seasonLog.fgBlk = result[12];
                defense.seasonLog.xpBlk = result[13];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGame(string gameid)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.team.abbr);
                values.Add("@GameID", gameid);
                DefenseGameStats gameStats = new DefenseGameStats();
                string[] result = SelectProc("GetDefenseGameStats", values)[0];
                if(defense.gameLogs == null)
                {
                    defense.gameLogs = new List<DefenseGameStats>();
                }
                defense.team.abbr = result[0];
                defense.team.city = result[1];
                defense.team.name = result[2];
                gameStats.game.gameid = result[3];
                gameStats.game.date = result[4];
                gameStats.game.time = result[5];
                gameStats.game.homeTeam.abbr = result[6];
                gameStats.game.homeTeam.city = result[7];
                gameStats.game.homeTeam.name = result[8];
                gameStats.game.awayTeam.abbr = result[9];
                gameStats.game.awayTeam.city = result[10];
                gameStats.game.awayTeam.name = result[11];
                gameStats.stats.pa = result[12];
                gameStats.stats.sck = result[13];
                gameStats.stats.fum = result[14];
                gameStats.stats.intc = result[15];
                gameStats.stats.intTd = result[16];
                gameStats.stats.fumTd = result[17];
                gameStats.stats.sfty = result[18];
                gameStats.stats.krTd = result[19];
                gameStats.stats.prTd = result[20];
                gameStats.stats.fgBlk = result[21];
                gameStats.stats.xpBlk = result[22];
                defense.gameLogs.Add(gameStats);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void GetGameLogs()
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.team.abbr);
                DefenseGameStats gameStats;
                List<string[]> results = SelectProc("GetDefenseGameLogs", values);
                defense.gameLogs = new List<DefenseGameStats>();
                defense.team.abbr = results[0][0];
                defense.team.city = results[0][1];
                defense.team.name = results[0][2];
                foreach (string[] result in results)
                {
                    gameStats = new DefenseGameStats();
                    gameStats.game.gameid = result[3];
                    gameStats.game.date = result[4];
                    gameStats.game.time = result[5];
                    gameStats.game.homeTeam.abbr = result[6];
                    gameStats.game.homeTeam.city = result[7];
                    gameStats.game.homeTeam.name = result[8];
                    gameStats.game.awayTeam.abbr = result[9];
                    gameStats.game.awayTeam.city = result[10];
                    gameStats.game.awayTeam.name = result[11];
                    gameStats.stats.pa = result[12];
                    gameStats.stats.sck = result[13];
                    gameStats.stats.fum = result[14];
                    gameStats.stats.intc = result[15];
                    gameStats.stats.intTd = result[16];
                    gameStats.stats.fumTd = result[17];
                    gameStats.stats.sfty = result[18];
                    gameStats.stats.krTd = result[19];
                    gameStats.stats.prTd = result[20];
                    gameStats.stats.fgBlk = result[21];
                    gameStats.stats.xpBlk = result[22];
                    defense.gameLogs.Add(gameStats);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int InsertSeasonLog()
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.team.abbr);
                values.Add("@pa", defense.seasonLog.pa);
                values.Add("@sck", defense.seasonLog.sck);
                values.Add("@fum", defense.seasonLog.fum);
                values.Add("@intc", defense.seasonLog.intc);
                values.Add("@inttd", defense.seasonLog.intTd);
                values.Add("@fumtd", defense.seasonLog.fumTd);
                values.Add("@sfty", defense.seasonLog.sfty);
                values.Add("@krtd", defense.seasonLog.krTd);
                values.Add("@prtd", defense.seasonLog.prTd);
                values.Add("@fgblk", defense.seasonLog.fgBlk);
                values.Add("@xpblk", defense.seasonLog.xpBlk);
                effected = UpdateProc("InsertDefenseSeasonStats", values);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
        public int InsertGameLogs()
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (DefenseGameStats gameStats in defense.gameLogs)
                {
                    values = new Dictionary<string, string>();
                    values.Add("@GameID", gameStats.game.gameid);
                    values.Add("@Team", defense.team.abbr);
                    values.Add("@pa", gameStats.stats.pa);
                    values.Add("@sck", gameStats.stats.sck);
                    values.Add("@fum", gameStats.stats.fum);
                    values.Add("@intc", gameStats.stats.intc);
                    values.Add("@inttd", gameStats.stats.intTd);
                    values.Add("@fumtd", gameStats.stats.fumTd);
                    values.Add("@sfty", gameStats.stats.sfty);
                    values.Add("@krtd", gameStats.stats.krTd);
                    values.Add("@prtd", gameStats.stats.prTd);
                    values.Add("@fgblk", gameStats.stats.fgBlk);
                    values.Add("@xpblk", gameStats.stats.xpBlk);
                    effected += UpdateProc("InsertDefenseGameStats", values);
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}