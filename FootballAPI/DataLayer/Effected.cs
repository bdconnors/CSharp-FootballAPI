using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer
{
    public class Effected
    {
        public string message { get; set; }

        public Effected(int effected)
        {
            message = effected + "Rows Effeceted In The Database";
        }
        public Effected(string effected)
        {
            message = effected;
        }
    }
}