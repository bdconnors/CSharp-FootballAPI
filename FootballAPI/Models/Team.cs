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
       
        public Team(string abbr)
        {
            this.abbr = abbr;
        }
        public Team(string[] info)
        {
            abbr = info[0];
            city = info[1];
            name = info[2];

        }
        public Team()
        {

        }
        public void Set(string[] info)
        {
            abbr = info[0];
            city = info[1];
            name = info[2];
        }
        public string[] Get()
        {
            string[] info = new string[3];
            info[0] = abbr;
            info[1] = city;
            info[2] = name;
            return info;
        }
    }
}