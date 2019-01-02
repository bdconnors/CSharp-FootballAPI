namespace FootballAPI.Util
{
    interface ICumulStats : IPositionStats
    {
        string gamesPlayed { get; set; }
    }
}
