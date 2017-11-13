using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.Data.Model;
using System.Data.Entity.ModelConfiguration.Conventions;
using ControleFinanceiro.Data.Configuration;

namespace ControleFinanceiro.Data.Context
{
    public class DbFinancaContext : DbContext
    {
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<ContaContabil> ContaContabil { get; set; }
        public DbSet<CentroContabil> CentroContabil { get; set; }
        public DbSet<Movimento> Movimento { get; set; }
        public DbSet<MovimentoRateio> MovimentoRateio { get; set; }
        public DbSet<MovimentoBaixa> MovimentoBaixa { get; set; }
        public DbSet<Investimento> Investimento { get; set; }
        public DbSet<InvestimentoMov> InvestimentoMov { get; set; }

        public DbFinancaContext() : base ("FinancaContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new ContaBancariaConfiguration());
            modelBuilder.Configurations.Add(new ContaContabilConfiguration());
            modelBuilder.Configurations.Add(new CentroContabilConfiguration());
            modelBuilder.Configurations.Add(new MovimentoConfiguration());
            modelBuilder.Configurations.Add(new MovimentoRateioConfiguration());
            modelBuilder.Configurations.Add(new MovimentoBaixaConfiguration());
            modelBuilder.Configurations.Add(new InvestimentoConfiguration());
            modelBuilder.Configurations.Add(new InvestimentoMovConfiguration());

            modelBuilder.Properties<string>().Configure(x => x.HasMaxLength(255));
            modelBuilder.Properties<decimal>().Configure(x => x.HasPrecision(18, 2));
            modelBuilder.Properties<bool>().Configure(x => x.IsOptional());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
