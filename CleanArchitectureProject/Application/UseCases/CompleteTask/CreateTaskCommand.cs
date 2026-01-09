namespace CleanArchitectureProject.Application.UseCases.CompleteTask
{
    public class CreateTaskCommand
    {
        public string Title { get; init; } = string.Empty;
        public string? Description { get; init; }
    }
}