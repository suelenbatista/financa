using ControleFinanceiro.Data.Enum;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Data.Model
{
    public class ContaContabil
    {
        public int IdContaContabil { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public GrupoContabil Grupo { get; set; }
        public TipoContaContabil Tipo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<MovimentoRateio> MovimentosRateio { get; set; }
    }
}
