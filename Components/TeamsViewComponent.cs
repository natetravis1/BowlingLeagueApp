using System;
using System.Linq;
using BowlingLeagueApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BowlingLeagueApp.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository _repo { get; set; }

        public TeamsViewComponent(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var teams = _repo.Bowlers
                .Select(x => x.Team.TeamName)
                .Distinct();

            return View(teams);
        }
    }
}
