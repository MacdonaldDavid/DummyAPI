using Microsoft.AspNetCore.Mvc;
using DummyAPI.Data;
using DummyAPI.Models;

namespace DummyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActivitiesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllActivities()
        {
            return Ok(_context.Activities.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetActivityById(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }

        [HttpPost]
        public IActionResult CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetActivityById), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActivity(int id, Activity updatedActivity)
        {
            var activity = _context.Activities.Find(id);
            if (activity == null) return NotFound();

            activity.Name = updatedActivity.Name;
            activity.Description = updatedActivity.Description;
            activity.TripId = updatedActivity.TripId;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActivity(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity == null) return NotFound();

            _context.Activities.Remove(activity);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
