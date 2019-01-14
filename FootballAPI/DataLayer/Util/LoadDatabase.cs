using FootballAPI.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Util
{
    public class LoadDatabase
    {
        private static Database db = new Database();
        public Season season { get; set; }
        public LoadDatabase(Season season)
        {
            this.season = season;
        }
        

    }
}