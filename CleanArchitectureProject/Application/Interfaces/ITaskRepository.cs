using CleanArchitectureProject.Domain;

namespace CleanArchitectureProject.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskItem?> GetByIdAsync(int id);

        Task SaveAsync(TaskItem task);

        Task<int> AddAsync(TaskItem task);
    }
}