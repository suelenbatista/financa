using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class InvestimentoConfiguration: EntityTypeConfiguration<Investimento>
    {
        public InvestimentoConfiguration()
        {
            ToTable("Investimento");
            HasKey(invest => invest.IdInvest);

            Property(invest => invest.Nome).IsOptional();
            Property(invest => invest.Descricao).IsOptional();

            HasMany(x => x.InvestimentoMov).WithRequired(x => x.Investimento)
                    .HasForeignKey(x => new { x.IdInvest });
        }
    }
}
