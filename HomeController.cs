using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    public class HomeController : Controller
    {
        private IRepositiory repositiory { get; set; }

        public HomeController(IRepositiory repo)
        {
            repositiory = repo;
        }

        public ViewResult Index() => View(repositiory.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            repositiory.AddReservation(reservation);
            return RedirectToAction("Index");
        }


    }
}
