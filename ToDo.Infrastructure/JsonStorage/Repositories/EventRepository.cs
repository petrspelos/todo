using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Events;

namespace ToDo.Infrastructure.JsonStorage.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ToDoContext _context;

        public EventRepository(ToDoContext context)
        {
            _context = context;
        }

        public Task Add(ICalendarEvent cEvent)
        {
            _context.CalendarEvents.Add((CalendarEvent)cEvent);
            _context.Serialize();
            return Task.CompletedTask;
        }

        public Task<bool> Exists(Guid id)
            => Task.FromResult(_context.CalendarEvents.Any(e => e.Id == id));

        public Task<IEnumerable<ICalendarEvent>> GetAll()
        {
            return Task.FromResult(_context.CalendarEvents.Select(e => (ICalendarEvent)e));
        }

        public Task<ICalendarEvent> Remove(Guid id)
        {
            var toRemove = _context.CalendarEvents.SingleOrDefault(e => e.Id == id);

            if(toRemove is null)
                return null;

            _context.CalendarEvents.Remove(toRemove);
            _context.Serialize();

            return Task.FromResult((ICalendarEvent)toRemove);
        }
    }
}
