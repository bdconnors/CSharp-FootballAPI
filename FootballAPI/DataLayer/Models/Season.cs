using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Season
    {
        public string year { get; set; }
        public string type { get; set; }
        public bool playoffs { get; set; }

        public Season(string year,bool playoffs)
        {
            this.year = year;
            if (playoffs == true)
            {
                type = "-playoff";
            }
            else
            {
                type = "-regular";
            }

        }
        public Season(bool regularSeason)
        {
            year = DateTime.Now.Year.ToString();
            if (playoffs == true)
            {
                type = "-playoff";
            }
            else
            {
                type = "-regular";
            }
        }
        public Season()
        {

        }
    }
}