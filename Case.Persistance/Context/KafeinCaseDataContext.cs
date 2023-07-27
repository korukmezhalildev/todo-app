using Case.Domain.TodoModel;
using Case.Domain.UserModel;
using Microsoft.EntityFrameworkCore;

namespace Case.Persistance.Context;

public sealed class KafeinCaseDataContext : DbContext
{
    public KafeinCaseDataContext(DbContextOptions<KafeinCaseDataContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoFile> TodoFiles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder
                .UseSqlServer(@"ConnString")
                .EnableSensitiveDataLogging(false)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        base.OnConfiguring(optionsBuilder);
    }
}