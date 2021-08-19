using britanicoCore.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace britanicoDb.Data
{
    public class BritanicoContext : DbContext
    {

        public DbSet<LogError> LogError { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Numerador> Numerador { get; set; }
        public DbSet<ParametroEmpresa> ParametroEmpresa { get; set; }


        public BritanicoContext(DbContextOptions<BritanicoContext> opt) : base(opt)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
