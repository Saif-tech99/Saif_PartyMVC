using Microsoft.AspNetCore.Mvc;
using Saif_PartyMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace Saif_PartyMVC.Controllers
{
    public class VisitorsController : Controller
    {

        private List<Visitor> _visitors = new List<Visitor>();

        // GET - Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // POST - Create
        [HttpPost]
        public IActionResult Create(Visitor visitor)
        {
            _visitors.Add(visitor);
            return View();
        }


        [HttpGet]
        public IActionResult Summary()
        {
            TempData["TotalGuests"] = _visitors.Count;
            TempData["TotalFamilyMembers"] = _visitors.Count(x => x.IsFamily == true);
            TempData["YoungestGuestAge"] = _visitors.Count(x => x.Age < x.Age);
            TempData["OldestguestAge"] = _visitors.Count(x => x.Age > x.Age);

            return View();
        }

        [HttpPost]
        public IActionResult Summary(int id)
        {
            int totalG = (int)TempData.Peek("TotalGuests");
            int totalF = (int)TempData.Peek("TotalFamilyMembers");
            int totalY = (int)TempData.Peek("YoungestGuestAge");
            int totalO = (int)TempData.Peek("OldestguestAge");

            totalG = _visitors.Count;
            totalF = _visitors.Count(x => x.IsFamily == true);
            totalY = _visitors.Count(x => x.Age < x.Age);
            totalO = _visitors.Count(x => x.Age > x.Age);

            TempData["TotalGuests"] = totalG;
            TempData["TotalFamilyMembers"] = totalF;
            TempData["YoungestGuestAge"] = totalY;
            TempData["OldestguestAge"] = totalO;

            return View();
        }

    }
}
