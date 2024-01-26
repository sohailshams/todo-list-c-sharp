using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Database.Entities;

namespace ToDoList.Api.Database
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<TaskEntity> Tasks { get; set; }
    }
}
