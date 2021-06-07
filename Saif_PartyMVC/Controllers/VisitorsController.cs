using Microsoft.AspNetCore.Mvc;
using Saif_PartyMVC.Models;
using System.Collections.Generic;
using System.Linq;
using test.Repository;

namespace Saif_PartyMVC.Controllers
{
    public class VisitorsController : Controller
    {
        private readonly VisitorRepo _repo = new VisitorRepo();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Visitor visitor)
        {
            _repo.Add(visitor);
            return View();
        }


        [HttpGet]
        public IActionResult Summary()
        {
            TempData["TotalGuests"] = _repo.List.Count;
            TempData["TotalFamilyMembers"] = _repo.List.Count(x => x.IsFamily == true);
            TempData["YoungestGuestAge"] = _repo.List.Count(x => x.Age < x.Age);
            //TempData["YoungestGuestAge"] = _repo.List.OrderByDescending(x => x.Age).LastOrDefault();
            TempData["OldestguestAge"] = _repo.List.Count(x => x.Age > x.Age);

            return View();
        }

        [HttpPost]
        public IActionResult Summary(VisitorRepo visitor)
        {
            int x = (int)TempData.Peek("TotalGuests");
            int y = (int)TempData.Peek("TotalFamilyMembers");
            var z = TempData.Peek("YoungestGuestAge");
            var s = TempData.Peek("OldestguestAge");

            x = _repo.List.Count;
            y = _repo.List.Count(x => x.IsFamily == true);
            z = _repo.List.Count(x => x.Age < x.Age);
            s = _repo.List.Count(x => x.Age > x.Age);

            //z = _repo.List.OrderByDescending(x => x.Age).LastOrDefault();
            //s = _repo.List.OrderByDescending(x => x.Age).FirstOrDefault();

            TempData["TotalGuests"] = x;
            TempData["TotalFamilyMembers"] = y;
            TempData["YoungestGuestAge"] = z;
            TempData["OldestguestAge"] = s;

            return View();
        }
    }
}
