using CleanArchitectureProject.Application.UseCases.CompleteTask;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CreateTaskUseCaseTests
    {
        [Fact]
        public async Task CreateTask_WithTitle_ReturnsSuccess()
        {
            // Arrange
            var repository = new FakeTaskRepository();
            var useCase = new CreateTaskUseCase(repository);

            var command = new CreateTaskCommand
            {
                Title = "Test task",
                Description = "Some description"
            };

            // Act
            var result = await useCase.ExecuteAsync(command);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task CreateTask_WithoutTitle_ReturnsFailure()
        {
            // Arrange
            var repository = new FakeTaskRepository();
            var useCase = new CreateTaskUseCase(repository);

            var command = new CreateTaskCommand
            {
                Title = "",
                Description = "Some description"
            };

            // Act
            var result = await useCase.ExecuteAsync(command);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.Error.Should().Be("Title is required");
        }
    }
}