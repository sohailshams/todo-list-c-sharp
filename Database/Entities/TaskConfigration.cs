using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Api.Database.Entities
{
    public class TaskConfigration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title).IsRequired();
            builder.Property(t => t.Description).IsRequired();
        }
    }
}
