using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class DefenseGameService : Database
    {
        
        public void Get(DefenseLogs defenses)
        {
            try
            {
                List<string[]> results = SelectProc("GetAllDefenseGameLogs", null);
                Defense defense = null;
                DefenseGameStats gameStats = null;
                foreach (string[] result in results)
                {
                    if (defense == null || defense.defense.abbr != result[0])
                    {
                        if (defense != null)
                        {
                            defenses.defenseLogs.Add(defense);
                        }
                        defense = new Defense();
                        defense.gameLogs = new List<DefenseGameStats>();
                        defense.defense.abbr = result[0];
                        defense.defense.city = result[1];
                        defense.defense.name = result[2];
                    }
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
        public void Get(DefenseLogs defenses,string gameid)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@game", gameid } };
                List<string[]> results = SelectProc("GetAllDefensesStatsGame", values);
                Defense defense = null;
                DefenseGameStats gameStats = null;
                foreach (string[] result in results)
                {
                    if (defense == null || defense.defense.abbr != result[0])
                    {
                        if (defense != null)
                        {
                            defenses.defenseLogs.Add(defense);
                        }
                        defense = new Defense();
                        defense.gameLogs = new List<DefenseGameStats>();
                        defense.defense.abbr = result[0];
                        defense.defense.city = result[1];
                        defense.defense.name = result[2];
                    }
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
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(Defense defense,string gameid)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.defense.abbr);
                values.Add("@GameID", gameid);
                DefenseGameStats gameStats = new DefenseGameStats();
                string[] result = SelectProc("GetDefenseGameStats", values)[0];
                if(defense.gameLogs == null)
                {
                    defense.gameLogs = new List<DefenseGameStats>();
                }
                defense.defense.abbr = result[0];
                defense.defense.city = result[1];
                defense.defense.name = result[2];
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
        public void Get(Defense defense)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.defense.abbr);
                DefenseGameStats gameStats;
                List<string[]> results = SelectProc("GetDefenseGameLogs", values);
                defense.gameLogs = new List<DefenseGameStats>();
                defense.defense.abbr = results[0][0];
                defense.defense.city = results[0][1];
                defense.defense.name = results[0][2];
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
        public int Post(Defense defense)
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach (DefenseGameStats gameStats in defense.gameLogs)
                {
                    values = new Dictionary<string, string>();
                    values.Add("@GameID", gameStats.game.gameid);
                    values.Add("@Team", defense.defense.abbr);
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