using AccesoDatos.Modelos;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Datos;

public class ApplicationDbContext : DbContext
{
    public DbSet<Paciente> Pacientes => Set<Paciente>();
    public DbSet<Especialidad> Especialidades => Set<Especialidad>();
    public DbSet<Profesional> Profesionales => Set<Profesional>();
    public DbSet<Turno> Turnos => Set<Turno>();

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "sistemaTurnos.db");

            optionsBuilder.UseSqlite($"Data Source={ruta}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paciente>()
            .HasIndex(p => p.DNI)
            .IsUnique();

        modelBuilder.Entity<Profesional>()
            .HasIndex(p => p.Matricula)
            .IsUnique();

        modelBuilder.Entity<Especialidad>()
            .HasIndex(e => e.Nombre)
            .IsUnique();

        modelBuilder.Entity<Turno>()
            .HasIndex(t => new
            {
                t.ProfesionalId,
                t.Fecha,
                t.Hora
            })
            .IsUnique();

        modelBuilder.Entity<Profesional>()
            .HasOne(p => p.Especialidad)
            .WithMany(e => e.Profesionales)
            .HasForeignKey(p => p.EspecialidadId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Turno>()
            .HasOne(t => t.Paciente)
            .WithMany(p => p.Turnos)
            .HasForeignKey(t => t.PacienteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Turno>()
            .HasOne(t => t.Profesional)
            .WithMany(p => p.Turnos)
            .HasForeignKey(t => t.ProfesionalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}