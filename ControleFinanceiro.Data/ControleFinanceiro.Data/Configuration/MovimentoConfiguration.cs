using ControleFinanceiro.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class MovimentoConfiguration: EntityTypeConfiguration<Movimento>
    {
        public MovimentoConfiguration()
        {
            ToTable("Movimento");
            HasKey(mov => mov.IdMov);
            Property(mov => mov.Descricao).IsOptional();
            Property(mov => mov.ValorPago).IsOptional();
            Property(mov => mov.Provisao).IsOptional();

            HasMany(mov => mov.MovimentosRateio).WithRequired(x => x.Movimento)
                            .HasForeignKey(mov => new { mov.IdMov });

            HasMany(mov => mov.MovimentosBaixa).WithRequired(x => x.Movimento)
                            .HasForeignKey(mov => new { mov.IdMov });
        }
    }
}
