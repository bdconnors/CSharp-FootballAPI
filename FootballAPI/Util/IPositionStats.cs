using System.Collections.Generic;
using FootballAPI.Models;

namespace FootballAPI.Util
{
    interface IPositionStats : IStats
    {
        List<Stats> stats { get; set; }
    }
}
