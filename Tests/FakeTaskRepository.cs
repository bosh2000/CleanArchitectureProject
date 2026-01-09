using CleanArchitectureProject.Application.Interfaces;
using CleanArchitectureProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FakeTaskRepository : ITaskRepository
    {
        private readonly Dictionary<int, TaskItem> _storage = new();
        private int _nextId = 1;

        public Task<TaskItem?> GetByIdAsync(int id)
            => Task.FromResult(_storage.TryGetValue(id, out var task) ? task : null);

        public Task SaveAsync(TaskItem task)
        {
            if (task.Id == 0)
                task.AssignId(_nextId++);

            _storage[task.Id] = task;
            return Task.CompletedTask;
        }

        public async Task<int> AddAsync(TaskItem task)
        {
            if (task.Id == 0)
                task.AssignId(_nextId++);
            _storage[task.Id] = task;
            return task.Id;
        }
    }
}