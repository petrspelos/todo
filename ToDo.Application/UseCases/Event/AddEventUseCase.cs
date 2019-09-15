using System;
using System.Threading.Tasks;
using ToDo.Application.Boundaries.Event.Add;

namespace ToDo.Application.UseCases.Event
{
    public class AddEventUseCase : IAddEventUseCase
    {
        public Task Execute(AddEventInput input)
        {
            throw new Exception();
        }
    }
}
