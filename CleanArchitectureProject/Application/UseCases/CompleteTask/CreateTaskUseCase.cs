using CleanArchitectureProject.Application.Interfaces;
using CleanArchitectureProject.Application.Results;
using CleanArchitectureProject.Domain;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureProject.Application.UseCases.CompleteTask
{
    public class CreateTaskUseCase
    {
        private readonly ITaskRepository _repository;

        public CreateTaskUseCase(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<int>> ExecuteAsync(CreateTaskCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Title))
                return Result<int>.Failure("Title is required");

            var task = TaskItem.Create(
                command.Title,
                command.Description
            );

            await _repository.AddAsync(task);

            return Result<int>.Success(task.Id);
        }
    }
}