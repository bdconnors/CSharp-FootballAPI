using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Services
{
    public class DefenseSeasonService : Database
    {
       
        public void Get(DefenseLogs defenses)
        {
            try
            {
                List<string[]> results = SelectProc("GetAllDefenseSeasonStats", null);
                Defense defense;
                foreach (string[] result in results)
                {
                    defense = new Defense();
                    defense.seasonLog = new DefenseStats();
                    defense.defense.abbr = result[0];
                    defense.defense.city = result[1];
                    defense.defense.name = result[2];
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
                    defenses.defenseLogs.Add(defense);
                }
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
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@Team", defense.defense.abbr } };
                string[] result = SelectProc("GetDefenseSeasonStats", values)[0];
                defense.seasonLog = new DefenseStats();
                defense.defense.abbr = result[0];
                defense.defense.city = result[1];
                defense.defense.name = result[2];
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
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public int Insert(Defense defense)
        {
            int effected = 0;
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>();
                values.Add("@Team", defense.defense.abbr);
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
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            return effected;
        }
    }
}