using BowlingLeagueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueApp.Controllers
{
    public class HomeController : Controller
    {
        private IBowlersRepository _repo { get; set; }

        // constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string teamname)
        {
            var x = _repo.Bowlers
            .Where(x => x.Team.TeamName == teamname || teamname == null);


            return View(_repo.Bowlers.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Bowler());
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            _repo.SaveBowler(b);
            return View("Index", _repo.Bowlers.ToList());
        }

        [HttpGet]
        public IActionResult Edit(int BowlerID)
        {
            var b = _repo.Bowlers.Single(i => i.BowlerID == BowlerID);

            return View("Add", b);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            _repo.UpdateBowler(b);
            _repo.SaveBowler(b);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var b = _repo.Bowlers.Single(i => i.BowlerID == bowlerid);

            return View(b);
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            _repo.DeleteBowler(b);
            return RedirectToAction("Index", _repo.Bowlers.ToList());
        }
    }
}
