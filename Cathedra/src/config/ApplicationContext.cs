using Cathedra.model;
using Microsoft.EntityFrameworkCore;

namespace Cathedra.config;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Worker?> Worker { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройки для Album
        modelBuilder.Entity<Worker>()
            .ToTable("worker")
            .HasKey(w => w.id);
        
        modelBuilder.Entity<Worker>()
            .Property(w => w.name)
            .IsRequired();
        
        modelBuilder.Entity<Lesson>()
            .ToTable("lesson")
            .HasKey(l => l.id);

        modelBuilder.Entity<Lesson>()
            .Property(l => l.disciplineId)
            .IsRequired(); 
        
        modelBuilder.Entity<Discipline>()
            .ToTable("discipline")
            .HasKey(d => d.id);

        modelBuilder.Entity<Discipline>()
            .Property(d => d.name)
            .IsRequired(); 

        modelBuilder.Entity<Discipline>()
            .Property(d => d.name)
            .IsRequired(); 
        
        modelBuilder.Entity<Discipline>()
            .HasOne<Worker>()
            .WithMany()
            .HasForeignKey(d => d.professorId);
        
        modelBuilder.Entity<Discipline>()
            .HasOne<Worker>()
            .WithMany()
            .HasForeignKey(d => d.helperId);

        modelBuilder.Entity<Lesson>()
            .HasOne<Discipline>()
            .WithMany()
            .HasForeignKey(d => d.disciplineId);
    }
}