using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Entidades.Entidade
{
    public class CentroContabil
    {
        public int IdCentro { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual ICollection<MovimentoRateio> MovimentosRateio { get; set; }
    }
}
