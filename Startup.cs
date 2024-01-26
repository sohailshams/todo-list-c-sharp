using Microsoft.EntityFrameworkCore;
using Npgsql;
using ToDoList.Api.Database;
using ToDoList.Api.Repositories;

namespace ToDoList.Api
{
    public class Startup
    {
        public void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("PostgresConnection");
            var connectionBuilder = new NpgsqlConnectionStringBuilder(connectionString);

            services.AddPooledDbContextFactory<ToDoListContext>(options =>
                options.UseNpgsql(
                    connectionBuilder.ConnectionString,
                    options =>
                    {
                        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    }));

            services.AddSingleton<TaskRepository>();
        }
    }
}
