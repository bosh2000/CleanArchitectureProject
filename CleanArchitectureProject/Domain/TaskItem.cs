using CleanArchitectureProject.Domain.Exceptions;

namespace CleanArchitectureProject.Domain
{
    public class TaskItem
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public bool? IsCompleted { get; private set; }

        private TaskItem()
        {
        }

        public static TaskItem Create(string title, string? description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Task title cannot be empty");

            return new TaskItem
            {
                Title = title,
                Description = description,
                IsCompleted = false
            };
        }

        public void Complete()
        {
            if (string.IsNullOrWhiteSpace(Description))
                throw new InvalidOperationException("Desciption is empty");
            IsCompleted = true;
        }

        public void AssignId(int id) => Id = id;
    }
}