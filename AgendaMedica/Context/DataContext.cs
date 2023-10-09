using AgendaMedica.Mapping;
using AgendaMedica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaMedica.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacienteMap());
            //modelBuilder.ApplyConfiguration(new AgendamentoMap());
        }

        public DbSet<PacienteMOD> Pacientes { get; set; }

        public DbSet<MedicoMOD> Medicos { get; set; }

        public DbSet<AgendamentoMOD> Agendamento { get; set; }

    }
}
