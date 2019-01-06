using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class DefenseGameStats
    {
        public string team { get; set; }
        public string gameid { get; set; }
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

        public DefenseGameStats(string team)
        {
            this.team = team;
        }
        public DefenseGameStats()
        {
        }
        public void Set(string[] stats)
        {
            team = stats[0];
            gameid = stats[1];
            pa = stats[2];
            sck = stats[3];
            fum = stats[4];
            intc = stats[5];
            intTd = stats[6];
            fumTd = stats[7];
            sfty = stats[8];
            krTd = stats[9];
            prTd = stats[10];
            fgBlk = stats[11];
            xpBlk = stats[12];
        }
        public string[] Get()
        {
            string[] stats = new string[13];
            stats[0] = team;
            stats[1] = gameid;
            stats[2] = pa;
            stats[3] = sck;
            stats[4] = fum;
            stats[5] = intc;
            stats[6] = intTd;
            stats[7] = fumTd;
            stats[8] = sfty;
            stats[9] = krTd;
            stats[10] = prTd;
            stats[11] = fgBlk;
            stats[12] = xpBlk;
            return stats;
        }
    }
}