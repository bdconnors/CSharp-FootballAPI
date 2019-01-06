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
        public void Set(string[] info)
        {
            playerid = info[0];
            fname = info[1];
            lname = info[2];
            number = info[3];
            position = info[4];
            team = info[5];
        }
        public string[] Get()
        {
            string[] info = new string[6];
            info[0] = playerid;
            info[1] = fname;
            info[2] = lname;
            info[3] = number;
            info[4] = position;
            info[5] = team;
            return info;
        }
    }
}