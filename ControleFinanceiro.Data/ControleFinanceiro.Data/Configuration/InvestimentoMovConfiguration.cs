using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class InvestimentoMovConfiguration: EntityTypeConfiguration<InvestimentoMov>
    {
        public InvestimentoMovConfiguration()
        {
            ToTable("InvestimentoMov");
            HasKey(investMov => investMov.IdInvestMov);
            Property(investMov => investMov.IdConta).IsRequired();

            Property(investMov => investMov.Envolvido).IsOptional();
            Property(investMov => investMov.Descricao).IsOptional();
            Property(investMov => investMov.Rentabilidade).IsOptional();
        }
    }
}
