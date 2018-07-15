using JoseBeloDelfino.Domain.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JoseBeloDelfino.Data.Contexto
{
    public class JoseBeloDelfinoDbContexto : DbContext
    {
        public JoseBeloDelfinoDbContexto()
            : base("BancoJoseBeloDelfinoConnection")
        {
            Database.SetInitializer<JoseBeloDelfinoDbContexto>(null);
            Database.CommandTimeout = 60;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<FuncionarioEntity> Funcionario { get; set; }
        public DbSet<LoginEntity> Login { get; set; }
        public DbSet<DepartamentoEntity> Departamento { get; set; }
        public DbSet<CargoEntity> Cargo { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
        }
    }
}
