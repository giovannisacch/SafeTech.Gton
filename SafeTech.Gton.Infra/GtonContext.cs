using Microsoft.EntityFrameworkCore;
using SafeTech.Gton.Infra.Data.Models;

namespace SafeTech.Gton.Infra.Data
{
    public class GtonContext : DbContext
    {
        public GtonContext(DbContextOptions<GtonContext> options) 
            : base(options)
        {
        }
        public DbSet<Organ> Organs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OrganType> OrganTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<MedicalUnity> MedicalUnities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GtonContext).Assembly);
            //Metodo acima pega as configuracoes das classes que estao com o DbSet
        }
    }
}
