using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class PlayerGameStats
    {
        [JsonIgnore]
        public string playerid { get; set; }
        [JsonIgnore]
        public string gameid { get; set; }
        public string passAtt { get; set; }
        public string passComp { get; set; }
        public string passYds { get; set; }
        public string passTds { get; set; }
        public string intc { get; set; }
        public string rushAtt { get; set; }
        public string rushYds { get; set; }
        public string rushTds { get; set; }
        public string fum { get; set; }
        public string rec { get; set; }
        public string recYds { get; set; }
        public string recTds { get; set; }
        public string fgAtt { get; set; }
        public string fgMade { get; set; }
        public string xpAtt { get; set; }
        public string xpMade { get; set; }
        public string fgPct { get; set; }
        public string xpPct { get; set; }

        public PlayerGameStats(string playerid,string gameid)
        {
            this.playerid = playerid;
            this.gameid = gameid;

        }
        public PlayerGameStats()
        {

        }
        public void Set(string[] stats)
        {
            playerid = stats[0];
            gameid = stats[1];
            passAtt = stats[2];
            passComp = stats[3];
            passYds = stats[4];
            passTds = stats[5];
            intc = stats[6];
            rushAtt = stats[7];
            rushYds = stats[8];
            rushTds = stats[9];
            fum = stats[10];
            rec = stats[11];
            recYds = stats[12];
            recTds = stats[13];
            fgAtt = stats[14];
            fgMade = stats[15];
            xpAtt = stats[16];
            xpMade = stats[17];
            fgPct = stats[18];
            xpPct = stats[19];
        }
        public string[] Get()
        {
            string[] stats = new string[20];
            stats[0] = playerid;
            stats[1] = gameid;
            stats[2] = passAtt;
            stats[3] = passComp;
            stats[4] = passYds;
            stats[5] = passTds;
            stats[6] = intc;
            stats[7] = rushAtt;
            stats[8] = rushYds;
            stats[9] = rushTds;
            stats[10] = fum;
            stats[11] = rec;
            stats[12] = recYds;
            stats[13] = recTds;
            stats[14] = fgAtt;
            stats[15] = fgMade;
            stats[16] = xpAtt;
            stats[17] = xpMade;
            stats[18] = fgPct;
            stats[19] = xpPct;
            return stats;
        }
    }
}