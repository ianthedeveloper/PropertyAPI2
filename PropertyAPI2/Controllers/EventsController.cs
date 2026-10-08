using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyAPI2.Services;

namespace PropertyAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public EventsController(ApplicationDbContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = Context.Events.OrderByDescending(e => e.Id).ToList();
            return Ok(events);
        }


        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var eventItem = Context.Events.Find(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return Ok(eventItem);
        }

        [HttpPost]
        public IActionResult CreateEvent(Models.EventDto eventDto)
        {
            // Implementation for creating an event
            var evt = new Models.Event
            {
                Title = eventDto.Title,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                AllDay = eventDto.AllDay
            };

            Context.Events.Add(evt);
            Context.SaveChanges();
            return Ok(evt);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, Models.EventDto eventDto)
        {
            var evt = Context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }

            evt.Title = eventDto.Title;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.AllDay = eventDto.AllDay;

            Context.SaveChanges();
            return Ok(evt);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var evt = Context.Events.Find(id);
            if (evt == null)
            {
                return NotFound();
            }

            Context.Events.Remove(evt);
            Context.SaveChanges();
            return NoContent();
        }
    }
}
