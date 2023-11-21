using Microsoft.EntityFrameworkCore;
using TaskTrackerApp.Models;


namespace TaskTracker.Data
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions options) : base(options)
        {

        }

       public  DbSet<Todo> Todos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasData(
         new Todo
         {
             TaskTodoId = 1,
             TaskTodoName = "Complete Project",
             TaskTodoDescription = "Finish the web application project",
             TaskTodoDate = DateTime.Now.AddDays(1) 
         },
         new Todo
         {
             TaskTodoId = 2,
             TaskTodoName = "Read Book",
             TaskTodoDescription = "Read a new book on software development",
             TaskTodoDate = DateTime.Now.AddDays(2)
         },
         new Todo
         {
             TaskTodoId = 3,
             TaskTodoName = "Exercise",
             TaskTodoDescription = "Go for a run or hit the gym",
             TaskTodoDate = DateTime.Now.AddDays(3)
         }
             );
            // This calls the base method, but does nothing
            base.OnModelCreating(modelBuilder);
        }
    }
}
