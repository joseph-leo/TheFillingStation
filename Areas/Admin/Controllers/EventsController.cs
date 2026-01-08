using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheFillingStation.Areas.Admin.Models;
using TheFillingStation.Data;
using TheFillingStation.Entities;
using TheFillingStation.Models;

namespace TheFillingStation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController(ApplicationDbContext context) : Controller
    {
        // GET: Admin/Events
        public async Task<IActionResult> Index()
        {
            var eventEntities = await context.Events.ToListAsync();
            List<EventListItemVm> events = [];
            foreach (var eventEntity in eventEntities)
            {
                events.Add(new EventListItemVm()
                {
                    Id = eventEntity.Id,
                    Title = eventEntity.Title,
                    EventDate = eventEntity.EventDate,
                    StartTime = eventEntity.StartTime,
                    EndTime = eventEntity.EndTime,
                    Badge = eventEntity.Badge,
                });
            }
            return View(events);
        }

        // GET: Admin/Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntity = await context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            EventDetailsVm eventDetails = new()
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                EventDate = eventEntity.EventDate,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Summary = eventEntity.Summary,
                Badge = eventEntity.Badge,
            };
            
            return View(eventDetails);
        }

        // GET: Admin/Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateVm createdEvent)
        {
            if (ModelState.IsValid)
            {
                Event eventEntity = new()
                {
                    Title = createdEvent.Title,
                    EventDate = createdEvent.EventDate,
                    StartTime = createdEvent.StartTime,
                    EndTime = createdEvent.EndTime,
                    Summary = createdEvent.Summary,
                    Badge = createdEvent.Badge,
                };
                context.Add(eventEntity);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createdEvent);
        }

        // GET: Admin/Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntity = await context.Events.FindAsync(id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            EventEditVm eventToEdit = new()
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                EventDate = eventEntity.EventDate,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Summary = eventEntity.Summary,
                Badge = eventEntity.Badge,
            };
            
            return View(eventToEdit);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventEditVm editeEvent)
        {
            if (id != editeEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Event eventEntity = new()
                {
                    Id = editeEvent.Id,
                    Title = editeEvent.Title,
                    EventDate = editeEvent.EventDate,
                    StartTime = editeEvent.StartTime,
                    EndTime = editeEvent.EndTime,
                    Summary = editeEvent.Summary,
                    Badge = editeEvent.Badge,
                };
                try
                {
                    
                    context.Update(eventEntity);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(eventEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editeEvent);
        }

        // GET: Admin/Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventEntity = await context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventEntity == null)
            {
                return NotFound();
            }

            EventDeleteVm eventToDelete = new()
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                EventDate = eventEntity.EventDate,
                StartTime = eventEntity.StartTime,
                EndTime = eventEntity.EndTime,
                Badge = eventEntity.Badge,
            };

            return View(eventToDelete);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deletedEvent = await context.Events.FindAsync(id);
            if (deletedEvent != null)
            {
                context.Events.Remove(deletedEvent);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return context.Events.Any(e => e.Id == id);
        }
    }
}
