using Microsoft.EntityFrameworkCore;
using MinimalApiTryout.ClassLibrary.Models;

namespace MinimalApiTryout.ClassLibrary;
public class AppDbContext : DbContext
{
	public DbSet<IpRequest> IpRequests { get; set; }
    public AppDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=uniqueRequests.db");
    }
}
