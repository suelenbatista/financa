using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class MovimentoRateioConfiguration: EntityTypeConfiguration<MovimentoRateio>
    {
        public MovimentoRateioConfiguration()
        {
            ToTable("MovimentoRateio");
            HasKey(movRateio => movRateio.IdMovRateio);

            Property(movRateio => movRateio.Obs).IsOptional();
            Property(movRateio => movRateio.IdMov).IsRequired();
            Property(movRateio => movRateio.IdContaContabil).IsRequired();
        }
    }
}
