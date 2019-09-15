using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Event.List;

namespace ToDo.WebApi.UseCases.ListEvents
{
    [ApiController]
    [Authorize]
    [Route("api/event")]
    public sealed class ListEventsController : Controller
    {
        private readonly IListEventsUseCase _useCase;
        private readonly ListEventsPresenter _presenter;

        public ListEventsController(IListEventsUseCase useCase, ListEventsPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            await _useCase.Execute();
            return _presenter.ViewModel;
        }
    }
}
