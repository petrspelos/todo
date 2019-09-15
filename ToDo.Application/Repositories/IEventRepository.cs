using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Events;

namespace ToDo.Application.Repositories
{
    public interface IEventRepository
    {
        Task Add(ICalendarEvent cEvent);
        Task<IEnumerable<ICalendarEvent>> GetAll();
    }
}
