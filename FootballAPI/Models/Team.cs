using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Team
    {
        public string abbr { get; set; }
        public string city { get; set; }
        public string name { get; set; }
       
        public Team(string[] teamInfo)
        {
            abbr = teamInfo[0];
            city= teamInfo[1];
            name = teamInfo[2];
        }
        public Team(string abbr)
        {
            this.abbr = abbr;
        }
        public Team()
        {

        }
    }
}