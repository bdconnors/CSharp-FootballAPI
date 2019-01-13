using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class Defense
    {
        public Team defense { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DefenseStats seasonLog { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<DefenseGameStats> gameLogs { get; set; }

        public Defense(string team, DefenseStats seasonLog,List<DefenseGameStats> gameLogs)
        {
            defense = new Team(team);
            this.seasonLog = seasonLog;
            this.gameLogs = gameLogs;
        }
        public Defense(string team, List<DefenseGameStats> gameLogs)
        {
            defense = new Team(team);
            this.gameLogs = gameLogs;
        }
        public Defense(string team,DefenseStats seasonLog)
        {
            defense = new Team(team);
            this.seasonLog = seasonLog;
        }
        public Defense(string team)
        {
            defense = new Team(team);
        }
        public Defense()
        {
            defense = new Team();
        }
    }
}