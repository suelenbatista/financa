using ControleFinanceiro.Entidades.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class CentroContabilConfiguration: EntityTypeConfiguration<CentroContabil>
    {
        public CentroContabilConfiguration()
        {
            ToTable("CentroContabil");
            HasKey(cc => cc.IdCentro);

            Property(cc => cc.Codigo).IsRequired();
            Property(cc => cc.Descricao).IsRequired();

            HasMany(centroCusto => centroCusto.MovimentosRateio).WithRequired(centroCusto => centroCusto.CentroContabil)
                    .HasForeignKey(centroCusto => new { centroCusto.IdCentro });
        }
    }
}
