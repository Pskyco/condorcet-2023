using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Persistence;

public class PcrContext : DbContext
{
    public DbSet<PcrTest> PcrTests { get; set; }
    public DbSet<User> Users { get; set; }
    //public string DbPath { get; set; }

    public PcrContext()
    {
        //DbPath = @"D:\# BAC CYBER SECURITE\condorcet-2023\DB\PcrDatabase.db";
    }

    public PcrContext(DbContextOptions<PcrContext> options) : base(options)
    {
    }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Scaffold database / db-first

        // Entity Framework Fluent API
        // modelBuilder.Entity<PcrTest>().Property(x => x.CreationDate).HasDefaultValue(DateTime.Now)
        // attention si vous changez de moteur de base de données, par exemple ici 'datetime()' n'est valide qu'en SQLite.
        // par exemple en Oracle SQL, c'est plutôt 'GETDATE()' qui sera utilisé.
        modelBuilder.Entity<PcrTest>().Property(x => x.CreationDate).HasDefaultValueSql("datetime()");
        modelBuilder.Entity<PcrTest>().Property(x => x.AnalysisResultEnum).HasConversion<string>();
        modelBuilder.Entity<PcrTest>().Property(x => x.LogisticStatusEnum).HasConversion<string>();
        //modelBuilder.Entity<PcrTest>().Property(x => x.Code).HasMaxLength(8);

        modelBuilder.Entity<User>().HasData(
            new User()
            {
                Id = 1,
                Firstname = "Ludwig",
                Lastname = "Lebrun"
            },
            new User()
            {
                Id = 2,
                Firstname = "Hicham",
                Lastname = "Erradi"
            }
        );
    }
}