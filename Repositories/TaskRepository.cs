using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Database;
using ToDoList.Api.Database.Entities;

namespace ToDoList.Api.Repositories
{
    public class TaskRepository
    {
        private readonly IDbContextFactory<ToDoListContext> _dbContextFactory;
        public TaskRepository(IDbContextFactory<ToDoListContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<TaskEntity> GetAllTasks()
        {
            var context = _dbContextFactory.CreateDbContext();
            var tasks = context.Tasks.ToList();

            return tasks;
        }
        public TaskEntity? GetTask(int id)
        {
            var context = _dbContextFactory.CreateDbContext();
            var task = context.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
        }

        //change the name of method to save or create new task
        public TaskEntity PostTask(String title, String description)
        {
            var newTask = new TaskEntity
            {
                Title = title,
                Description = description
            };

            var context = _dbContextFactory.CreateDbContext();
            var task = context.Tasks.Add(newTask);
            context.SaveChanges();
            var entity = task.Entity;
            return entity;
        }

        public TaskEntity? DeleteTask(int id)
        {
            //use Select where instead of find
            var context = _dbContextFactory.CreateDbContext();
            var task = context.Tasks.SingleOrDefault(t => t.Id == id);
            if (task != null)
            {
                context.Tasks.Remove(task);
                context.SaveChanges();
                return task;
            }
            return task;

        }

        public TaskEntity? UpdateTask(int id, String title, String description)
        {
            var context = _dbContextFactory.CreateDbContext();
            var task = context.Tasks.Find(id);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
                context.SaveChanges();
                return task;
            }
            return task;

        }
    }
}
