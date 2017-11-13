using ControleFinanceiro.Data.Enum;
using System;
using System.Collections.Generic;

namespace ControleFinanceiro.Data.Model
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Movimento> Movimentos { get; set; }
    }
}
