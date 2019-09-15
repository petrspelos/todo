using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Application.Repositories;
using ToDo.Domain.Events;

namespace ToDo.Infrastructure.InMemoryStorage.Repositories
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
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ICalendarEvent>> GetAll()
        {
            return Task.FromResult(_context.CalendarEvents.Select(e => (ICalendarEvent)e));
        }
    }
}
