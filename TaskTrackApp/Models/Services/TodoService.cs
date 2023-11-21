using Microsoft.EntityFrameworkCore;
using TaskTrackerApp.Models.Interfaces;
using TaskTracker.Data;

namespace TaskTrackerApp.Models.Services
{
    public class TodoService : ITodo
    {
        private readonly TaskTrackerDbContext _dbContext;

        public TodoService(TaskTrackerDbContext db)
        {
            _dbContext = db;
        }
        public async Task<Todo> CreateNewTask(Todo task)
        {
            _dbContext.Add(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task DeleteTask(int Id)
        {
            var task = await _dbContext.Todos.FindAsync(Id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with id {Id} not found.");
            }
            _dbContext.Todos.Remove(task);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Todo>> GetAllTasks()
        {
            var tasks = await _dbContext.Todos.ToListAsync();
            return tasks;
        }

        public async Task<Todo> GetTaskById(int Id)
        {
            var task = await _dbContext.Todos.FirstOrDefaultAsync(t => t.TaskTodoId == Id);
            return task;
        }

        public async Task<Todo> UpdateTask(int Id, Todo task)
        {
            var existingTask = await _dbContext.Todos.FindAsync(Id);

            if (existingTask == null)
            {
                throw new KeyNotFoundException($"Task with id {Id} not found.");
            }
            existingTask.TaskTodoId = task.TaskTodoId;
            existingTask.TaskTodoName = task.TaskTodoName;
            existingTask.TaskTodoDescription = task.TaskTodoDescription;
            existingTask.TaskTodoDate = task.TaskTodoDate;

            _dbContext.Update(existingTask);
            await _dbContext.SaveChangesAsync();
            return task;
        }
    }
}
