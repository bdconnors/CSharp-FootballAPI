using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class DefenseLogs
    {
        public List<Defense> defenseLogs { get; set; }

        public DefenseLogs(List<Defense> defenseLogs)
        {
            this.defenseLogs = defenseLogs;
        }
        public DefenseLogs()
        {
            defenseLogs = new List<Defense>();
        }

    }
}