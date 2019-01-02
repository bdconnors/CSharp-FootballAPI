using FootballAPI.Util;

namespace FootballAPI.Models
{
    abstract class Stats : IStats
    {
        public abstract string id { get; set; }
        public abstract string playerid { get; set; }
    }
}
