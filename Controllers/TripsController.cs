using Microsoft.AspNetCore.Mvc;
using DummyAPI.Data;
using DummyAPI.Models;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TripsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllTrips()
        {
            return Ok(_context.Trips.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTripById(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        [HttpPost]
        public IActionResult CreateTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTripById), new { id = trip.Id }, trip);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTrip(int id, Trip updatedTrip)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null) return NotFound();

            trip.Destination = updatedTrip.Destination;
            trip.StartDate = updatedTrip.StartDate;
            trip.EndDate = updatedTrip.EndDate;
            trip.UserId = updatedTrip.UserId;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null) return NotFound();

            _context.Trips.Remove(trip);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
