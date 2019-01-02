namespace FootballAPI.Util
{
    interface IGameStats : IPositionStats 
    {
        string gameid { get; set; }
    }
}
