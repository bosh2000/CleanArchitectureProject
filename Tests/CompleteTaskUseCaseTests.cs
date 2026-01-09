using CleanArchitectureProject.Application.UseCases.CompleteTask;
using CleanArchitectureProject.Domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CompleteTaskUseCaseTests
    {
        [Fact]
        public async Task CompleteTask_WithDescription_CompletesSuccessfully()
        {
            // Arrange
            var repository = new FakeTaskRepository();
            var task = TaskItem.Create("Test task", "Some description");
            repository.AddAsync(task);

            var useCase = new CompleteTaskUseCase(repository);

            // Act
            await useCase.ExecuteAsync(new CompleteTaskCommand
            {
                TaskId = 1
            });

            // Assert
            task.IsCompleted.Should().BeTrue();
        }

        [Fact]
        public async Task CompleteTask_WithoutDescription_ThrowsException()
        {
            // Arrange
            var repository = new FakeTaskRepository();
            var task = TaskItem.Create("Test task", null);
            repository.AddAsync(task);

            var useCase = new CompleteTaskUseCase(repository);

            // Act
            Func<Task> act = async () =>
                await useCase.ExecuteAsync(new CompleteTaskCommand { TaskId = 1 });

            // Assert
            await act.Should()
                .ThrowAsync<InvalidOperationException>()
                .WithMessage("Desciption is empty");
        }

        [Fact]
        public async Task CompleteTask_TaskDoesNotExist_ThrowsException()
        {
            // Arrange
            var repository = new FakeTaskRepository();
            var useCase = new CompleteTaskUseCase(repository);

            // Act
            Func<Task> act = async () =>
                await useCase.ExecuteAsync(new CompleteTaskCommand { TaskId = 999 });

            // Assert
            await act.Should().ThrowAsync<Exception>()
                .WithMessage("Task not found");
        }
    }
}