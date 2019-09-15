using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.List;

namespace ToDo.WebApi.UseCases.ListTodos
{
    [ApiController]
    [Authorize]
    [Route("api/todo")]
    public sealed class ListTodosController : Controller
    {
        private readonly IListTodosUseCase _useCase;
        private readonly ListTodosPresenter _presenter;

        public ListTodosController(IListTodosUseCase useCase, ListTodosPresenter presenter)
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
