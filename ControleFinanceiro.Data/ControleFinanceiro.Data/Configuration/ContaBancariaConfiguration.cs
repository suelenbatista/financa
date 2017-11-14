using ControleFinanceiro.Entidades.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class ContaBancariaConfiguration: EntityTypeConfiguration<ContaBancaria>
    {
        public ContaBancariaConfiguration()
        {
            ToTable("ContaBancaria");
            HasKey(cb => cb.IdConta);

            Property(cb => cb.Banco).IsOptional();
            Property(cb => cb.Agencia).IsOptional();
            Property(cb => cb.AgenciaDig).IsOptional();
            Property(cb => cb.ContaCorrente).IsOptional();
            Property(cb => cb.ContaCorrenteDig).IsOptional();

            HasMany(conta => conta.MovimentosBaixa).WithRequired(x => x.ContaBacaria)
                  .HasForeignKey(conta => new { conta.IdConta });

            HasMany(conta => conta.InvestimentosMov).WithRequired(x => x.ContaBancaria)
                  .HasForeignKey(conta => new { conta.IdConta });
        }
    }
}
