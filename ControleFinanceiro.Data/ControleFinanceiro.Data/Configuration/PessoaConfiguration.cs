using ControleFinanceiro.Entidade.Entidade;
using System.Data.Entity.ModelConfiguration;

namespace ControleFinanceiro.Data.Configuration
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            ToTable("Pessoa");
            HasKey(pessoa => pessoa.IdPessoa);
            Property(x => x.Documento).IsOptional();

            HasMany(pessoa => pessoa.Movimentos).WithRequired(x => x.Pessoa)
                    .HasForeignKey(pessoa => new { pessoa.IdPessoa });
        }
    }
}
