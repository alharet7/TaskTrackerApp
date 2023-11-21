namespace TaskTrackerApp.Models.Interfaces
{
    public interface ITodo
    {
        Task<Todo> CreateNewTask(Todo task);
        Task<Todo> GetTaskById(int Id);
        Task<List<Todo>> GetAllTasks();
        Task<Todo> UpdateTask(int Id, Todo task);
        Task DeleteTask(int Id);
    }
}
