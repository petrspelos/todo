using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Boundaries.Todo.Add;

namespace ToDo.WebApi.UseCases.AddTodo
{
    [ApiController]
    [Authorize]
    [Route("api/todo")]
    public sealed class AddTodoController : Controller
    {
        private readonly IAddTodoUseCase _useCase;
        private readonly AddTodoPresenter _presenter;

        public AddTodoController(IAddTodoUseCase useCase, AddTodoPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody][Required]AddTodoTaskRequest request)
        {
            var input = new AddTodoInput(request.Name, request.Description, request.DueDate);
            await _useCase.Execute(input);
            return _presenter.ViewModel;
        }
    }
}
