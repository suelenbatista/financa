using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Configuration
{
    public class MovimentoBaixaConfiguration: EntityTypeConfiguration<MovimentoBaixa>
    {
        public MovimentoBaixaConfiguration()
        {
            ToTable("MovimentoBaixa");
            HasKey(movBaixa => movBaixa.IdBaixa);

            Property(movBaixa => movBaixa.Historico).IsOptional();
            Property(movBaixa => movBaixa.Transacao).IsOptional();
        }
    }
}
