using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.Add;

namespace ToDo.WebApi.UseCases.AddEvent
{
    [Authorize]
    [ApiController]
    [Route("api/event")]
    public sealed class AddEventController : Controller
    {
        private readonly IAddEventUseCase _useCase;
        private readonly AddEventPresenter _presenter;

        public AddEventController(IAddEventUseCase useCase, AddEventPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody][Required]AddEventRequest request)
        {
            var input = new AddEventInput(request.Name, request.Description, request.StartDate, request.Duration);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
