namespace FootballAPI.Models
{
    class RecStats : Stats
    {
        public override string id { get; set; }
        public override string playerid { get; set; }
        public string rec { get; set; }
        public string recYds { get; set; }
        public string recTds { get; set; }

        public RecStats(string[] stats)
        {
            playerid = stats[0];
            rec = stats[1];
            recYds= stats[2];
            recTds = stats[3];
        }
        public RecStats(string id)
        {
            this.id = id;
        }
        public RecStats()
        {

        }
    }
}
