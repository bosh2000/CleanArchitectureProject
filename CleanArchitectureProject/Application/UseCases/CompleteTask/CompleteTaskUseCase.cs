using CleanArchitectureProject.Application.Interfaces;
using CleanArchitectureProject.Application.Results;
using System.Runtime.InteropServices;

namespace CleanArchitectureProject.Application.UseCases.CompleteTask
{
    public class CompleteTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public CompleteTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> ExecuteAsync(CompleteTaskCommand command)
        {
            var task = await _repository.GetByIdAsync(command.TaskId);
            if (task == null)
                throw new Exception("Task not found");
            task.Complete();
            return Result.Success();
        }
    }
}