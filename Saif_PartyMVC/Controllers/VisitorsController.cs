using Microsoft.AspNetCore.Mvc;
using Saif_PartyMVC.Models;
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
            TempData["YoungestGuestAge"] = _repo.List.Count(x => x.Age < x.Age) ;
            TempData["OldestguestAge"] = _repo.List.Count(x => x.Age > x.Age);

            return View();
        }

        [HttpPost]
        public IActionResult Summary(VisitorRepo visitor)
        {
            int x = (int)TempData.Peek("TotalGuests");
            int y = (int)TempData.Peek("TotalFamilyMembers");
            int z = (int)TempData.Peek("YoungestGuestAge");
            int s = (int)TempData.Peek("OldestguestAge");

            x = _repo.List.Count;
            y = _repo.List.Count(x => x.IsFamily == true);
            z = _repo.List.Count(x => x.Age < x.Age).CompareTo(s);
            s = _repo.List.Count(x => x.Age > x.Age).CompareTo(z);

            TempData["TotalGuests"] = x;
            TempData["TotalFamilyMembers"] = y;
            TempData["YoungestGuestAge"] = z;
            TempData["OldestguestAge"] = s;

            return View();
        }
    }
}
