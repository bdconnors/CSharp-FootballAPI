using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class PlayerSeasonStats
    {
        [JsonIgnore]
        public string playerid { get; set; }
        public string gamesPlayed { get; set; }
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
        public string fgAtt { get; set; }
        public string fgMade { get; set; }
        public string xpAtt { get; set; }
        public string fgPct { get; set; }
        public string xpPct { get; set; }

        public PlayerSeasonStats(string playerid)
        {
            this.playerid = playerid;
        }
        public PlayerSeasonStats()
        {

        }

  
    }
}