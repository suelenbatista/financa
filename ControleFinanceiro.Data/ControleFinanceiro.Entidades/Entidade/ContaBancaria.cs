using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class ContaBancaria
    {
        public int IdConta { get; set; }
        public string Nome { get; set; }
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int AgenciaDig { get; set; }
        public int ContaCorrente { get; set; }
        public int ContaCorrenteDig { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<MovimentoBaixa> MovimentosBaixa { get; set; }
        public virtual ICollection<InvestimentoMov> InvestimentosMov { get; set; }
    }
}
