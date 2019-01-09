using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Defense
    {
        public Team team { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DefenseStats seasonLog { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DefenseGameStats> gameLogs { get; set; }

        public Defense(Team team, DefenseStats seasonLog,List<DefenseGameStats> gameLogs)
        {
            this.team = team;
            this.seasonLog = seasonLog;
            this.gameLogs = gameLogs;
        }
        public Defense(Team team, List<DefenseGameStats> gameLogs)
        {
            this.team = team;
            this.gameLogs = gameLogs;
        }
        public Defense(Team team,DefenseStats seasonLog)
        {
            this.team = team;
            this.seasonLog = seasonLog;
        }
        public Defense(Team team)
        {
            this.team = team;
        }
        public Defense()
        {
          
        }
    }
}