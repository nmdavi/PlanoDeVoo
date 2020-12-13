using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static PlanoDeVoo.Models.PlanoModels;

namespace PlanoDeVoo.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("PlanoConn")
        {
            Database.SetInitializer(new DbInitialize());
        }

        public DbSet<Plano> Planos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
