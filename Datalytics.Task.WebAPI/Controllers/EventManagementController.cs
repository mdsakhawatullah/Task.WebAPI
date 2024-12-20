using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datalytics.Task.WebAPI.DbConfigure;
using Datalytics.Task.WebAPI.Entities;
using System.Runtime.CompilerServices;

namespace Datalytics.Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventManagementController : ControllerBase
    {
        private readonly DatalyticsTaskDbContext _context;

        public EventManagementController(DatalyticsTaskDbContext context)
        {
            _context = context;
        }

        // GET: api/EventManagement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventManagementModel>>> GetEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // GET: api/EventManagement/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<EventManagementModel>> GetEventManagementModel(Guid id)
        {
            var eventManagementModel = await _context.Events.FindAsync(id);

            if (eventManagementModel == null)
            {
                return NotFound();
            }

            return eventManagementModel;
        }

        //GET: api/EventManagement/{eventDate}
        [HttpGet("{dateTime:datetime}")]
        public async Task<ActionResult<IEnumerable<EventManagementModel>>> GetManagementByDate(DateTime dateTime)
        {
            var model = await _context.Events
                        .Where(x => x.EventDate.Date == dateTime.Date)
                        .ToListAsync();
            return model;

        }

        // PUT: api/EventManagement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventManagementModel(Guid id, EventManagementModel eventManagementModel)
        {
            if (id != eventManagementModel.EventID)
            {
                return BadRequest();
            }

            _context.Entry(eventManagementModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/EventManagement
        [HttpPost]
        public async Task<ActionResult<EventManagementModel>> PostEventManagementModel(EventManagementModel eventManagementModel)
        {
            _context.Events.Add(eventManagementModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventManagementModel", new { id = eventManagementModel.EventID }, eventManagementModel);
        }

        // DELETE: api/EventManagement/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEventManagementModel(Guid id)
        {
            var eventManagementModel = await _context.Events.FindAsync(id);
            if (eventManagementModel == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventManagementModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
