using System.Threading.Tasks;

namespace ToDo.Application.Boundaries.Event.Remove
{
    public interface IRemoveEventUseCase
    {
        Task Execute(RemoveEventInput input);
    }
}
