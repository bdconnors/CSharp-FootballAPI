using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Models
{
    public class Player
    {
        public string playerid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string number { get; set; }
        public string position { get; set; }
        [JsonIgnore]
        public string team { get; set; }

        public Player(string playerid)
        {
            this.playerid = playerid;
        }
        public Player(string fname,string lname)
        {
            this.fname = fname;
            this.lname = lname;
        }
        public Player()
        {

        }
    }
}