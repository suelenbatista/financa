using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.Entidade.Enum;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class Movimento
    {
        public int IdMov { get; set; }
        public int IdPessoa { get; set; }
        public string Descricao { get; set; }
        public TipoMovimento Tipo { get; set; }
        public StatusMovimento Status { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorPago { get; set; }
        public bool Provisao { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<MovimentoRateio> MovimentosRateio { get; set; }
        public virtual ICollection<MovimentoBaixa> MovimentosBaixa { get; set; }
    }
}
