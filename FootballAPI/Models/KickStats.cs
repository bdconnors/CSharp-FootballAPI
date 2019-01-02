using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballAPI.Util;

namespace FootballAPI.Models
{
    class KickStats : Stats
    {
        public override string id { get; set; }
        public override string playerid { get; set; }
        public string fgAtt { get; set; }
        public string fgMade { get; set; }
        public string xpAtt { get; set; }
        public string xpMade { get; set; }

        public KickStats(string[] stats)
        {
            playerid = stats[0];
            fgAtt = stats[1];
            fgMade = stats[2];
            xpAtt = stats[3];
            xpMade = stats[4];
        }
        public KickStats(string id)
        {
            this.id = id;
        }
        public KickStats()
        {

        }
    }
}
