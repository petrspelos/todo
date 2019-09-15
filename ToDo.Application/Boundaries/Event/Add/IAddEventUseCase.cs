using System.Threading.Tasks;

namespace ToDo.Application.Boundaries.Event.Add
{
    public interface IAddEventUseCase
    {
        Task Execute(AddEventInput input);
    }
}
