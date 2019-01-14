using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Team
    {
        public string abbr { get; set; }
        public string city { get; set; }
        public string name { get; set; }
       
        public Team(string abbr)
        {
            this.abbr = abbr;
        }
        public Team()
        {

        }
    }
}