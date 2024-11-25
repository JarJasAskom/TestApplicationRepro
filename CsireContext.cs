using Microsoft.EntityFrameworkCore;

namespace MyApplication;


public class CsireContext : DbContext
{
    public DbSet<CsireRequest> Requests { get; set; } = null!;


    public CsireContext(DbContextOptions<CsireContext> aOptions)
       : base(aOptions)
    {

        SavingChanges += OnSavingChanges;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();



    protected override void OnModelCreating(ModelBuilder aModelBuilder)
    {
        OnModelCreating_Communication(aModelBuilder);
    }


    static void OnModelCreating_Communication(ModelBuilder aModelBuilder)
    {
        aModelBuilder
            .Entity<CsireRequest>()
            .ToTable(name: "Request", schema: "Communication");
    }


    protected override void ConfigureConventions(ModelConfigurationBuilder aConfigurationBuilder)
    {
        base.ConfigureConventions(aConfigurationBuilder);

        aConfigurationBuilder
            .Properties<Enum>()
            .HaveConversion<string>();
    }


    void OnSavingChanges(object? aSender, SavingChangesEventArgs aSavingChangesEventArgs)
    {
    }
}
