using HealthApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Record> Records { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }*/
}
