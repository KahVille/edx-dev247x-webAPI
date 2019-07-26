using Microsoft.EntityFrameworkCore;

namespace SakilaWebserver.Models
{
    class SakilaDbContext : DbContext {
    public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
    : base(options) { }

    public DbSet<Actor> Actor { get; set; }
    // DbSet<T> type properties for other domain models
    }

    /*
    To create the instance of SakilaDbContext we need a database connection string and few configurations steps. 
    Let's encapsulate the instance creation logic in a factory class for reuse.
    */
    class SakilaDbContextFactory {
    public static SakilaDbContext Create(string connectionString) {
        var optionsBuilder = new DbContextOptionsBuilder<SakilaDbContext>();
        optionsBuilder.UseMySQL(connectionString);
        var sakilaDbContext = new SakilaDbContext(optionsBuilder.Options);
        return sakilaDbContext;
    }

    }

}