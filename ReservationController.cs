using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        private IRepositiory repositiory { get; set; }

        public ReservationController(IRepositiory repo)
        {
            repositiory = repo;
        }

        [HttpGet]
        public IEnumerable<Reservation> Get() => repositiory.Reservations;

        [HttpGet("{id}")]
        public Reservation Get(int id) => repositiory[id];

        [HttpPost]
        public Reservation Post([FromBody] Reservation res) =>
            repositiory.AddReservation(new Reservation() {ClientName = res.ClientName, Location = res.Location});

        [HttpPut]
        public Reservation Put([FromBody] Reservation res) =>
            repositiory.UpdateReservation(res);

        [HttpDelete("{id}")]
        public void Delete(int id) => repositiory.DeleteReservation(id);

    }
}
