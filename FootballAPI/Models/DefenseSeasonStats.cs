using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class DefenseSeasonStats
    {
        public string team { get; set; }
        public string pa { get; set; }
        public string sck { get; set; }
        public string fum { get; set; }
        public string intc { get; set; }
        public string intTd { get; set; }
        public string fumTd { get; set; }
        public string sfty { get; set; }
        public string krTd { get; set; }
        public string prTd { get; set; }
        public string fgBlk { get; set; }
        public string xpBlk { get; set; }

        public DefenseSeasonStats(string team)
        {
            this.team = team;
        }
        public DefenseSeasonStats()
        {

        }

        public void Set(string[] stats)
        {
            team = stats[0];
            pa = stats[1];
            sck = stats[2];
            fum = stats[3];
            intc = stats[4];
            intTd = stats[5];
            fumTd = stats[6];
            sfty = stats[7];
            krTd = stats[8];
            prTd = stats[9];
            fgBlk = stats[10];
            xpBlk = stats[11];
        }
        public string[] Get()
        {
            string[] stats = new string[12];
            stats[0] = team;
            stats[1] = pa;
            stats[2] = sck;
            stats[3] = fum;
            stats[4] = intc;
            stats[5] = intTd;
            stats[6] = fumTd;
            stats[7] = sfty;
            stats[8] = krTd;
            stats[9] = prTd;
            stats[10] = fgBlk;
            stats[11] = xpBlk;
            return stats;
        }
    }
}