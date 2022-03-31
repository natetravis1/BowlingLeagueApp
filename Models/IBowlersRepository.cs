using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        void SaveBowler(Bowler b);
        void UpdateBowler(Bowler b);
        void DeleteBowler(Bowler b);
    }
}
