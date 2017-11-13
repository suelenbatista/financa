using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFinanceiro.Data.Enum;

namespace ControleFinanceiro.Data.Model
{
    public class MovimentoBaixa
    {
        public int IdBaixa { get; set; }
        public int IdMov { get; set; }
        public int IdConta { get; set; }
        public string Historico { get; set; }
        public TipoTransacao Transacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataBaixa { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Movimento Movimento { get; set; }
        public virtual ContaBancaria ContaBacaria { get; set; }
    }
}
