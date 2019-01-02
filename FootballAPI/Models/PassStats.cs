using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballAPI.Models
{
    class PassStats : Stats
    {
        public override string id { get; set; }
        public override string playerid { get; set; }
        public string passAtt { get; set; }
        public string passComp { get; set; }
        public string passYds { get; set; }
        public string passTds { get; set; }
        public string intc { get; set; }

        public PassStats(string[] stats)
        {
            playerid = stats[0];
            passAtt = stats[1];
            passComp = stats[2];
            passYds = stats[3];
            passTds = stats[4];
            intc = stats[5]; 
        }
        public PassStats(string id)
        {
            this.id = id;
        }
        public PassStats()
        {

        }
    }
}
