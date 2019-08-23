namespace ToDo
{
    public class AddTodoUseCase : IAddTodoUseCase
    {
        private readonly ITaskStorage _storage;

        public AddTodoUseCase(ITaskStorage storage)
        {
            _storage = storage;
        }

        public void Execute(string description)
        {
            if (description is null) { return; }
            _storage.Store(new TodoTask { Description = description });
        }
    }
}
