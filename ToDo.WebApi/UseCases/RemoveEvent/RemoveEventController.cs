using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.Remove;

namespace ToDo.WebApi.UseCases.RemoveEvent
{
    [ApiController]
    [Authorize]
    [Route("api/event")]
    public sealed class RemoveEventController : Controller
    {
        private readonly IRemoveEventUseCase _useCase;
        private readonly RemoveEventPresenter _presenter;

        public RemoveEventController(IRemoveEventUseCase useCase, RemoveEventPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove([FromBody][Required]RemoveEventRequest request)
        {
            var input = new RemoveEventInput(request.EventId);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
