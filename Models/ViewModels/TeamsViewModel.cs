using System;
using System.Linq;

namespace BowlingLeagueApp.Models.ViewModels
{
    public class TeamsViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
    }
}
