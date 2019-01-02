using System.Collections.Generic;
using FootballAPI.Util;

namespace FootballAPI.Models
{
    class WrGameStats : IGameStats
    {
        public string id { get; set; }
        public string playerid { get; set; }
        public string gameid { get; set; }
        public List<Stats> stats { get; set;}
    }
}
