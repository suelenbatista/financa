using ControleFinanceiro.Entidade.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class ContaContabilConfiguration: EntityTypeConfiguration<ContaContabil>
    {
        public ContaContabilConfiguration()
        {
            ToTable("ContaContabil");
            HasKey(cc => cc.IdContaContabil);

            Property(cc => cc.Descricao).IsRequired();
            Property(cc => cc.Tipo).IsOptional();
            Property(cc => cc.Grupo).IsOptional();

            HasMany(contabil => contabil.MovimentosRateio).WithRequired(contabil => contabil.ContaContabil)
                    .HasForeignKey(contabil => new { contabil.IdContaContabil });
        }
    }
}
