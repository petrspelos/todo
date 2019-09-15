using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.Remove;

namespace ToDo.WebApi.UseCases.RemoveTodo
{
    [ApiController]
    [Authorize]
    [Route("api/todo")]
    public sealed class RemoveTodoController : Controller
    {
        private readonly IRemoveTodoUseCase _useCase;
        private readonly RemoveTodoPresenter _presenter;

        public RemoveTodoController(IRemoveTodoUseCase useCase, RemoveTodoPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> Remove([FromBody][Required]RemoveTodoRequest request)
        {
            var input = new RemoveTodoInput(request.TaskId);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
