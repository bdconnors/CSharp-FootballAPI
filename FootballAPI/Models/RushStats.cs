namespace FootballAPI.Models
{
    class RushStats : Stats
    {
        public override string id { get; set; }
        public override string playerid { get; set; }
        public string rushAtt { get; set; }
        public string rushYds { get; set; }
        public string rushTds { get; set; }
        public string fum { get; set; }

        public RushStats(string[] stats)
        {
            playerid = stats[0];
            rushAtt = stats[1];
            rushYds = stats[2];
            rushTds = stats[3];
            fum = stats[4];
        }
        public RushStats(string id)
        {
            this.id = id;
        }
        public RushStats()
        {

        }

    }
}
