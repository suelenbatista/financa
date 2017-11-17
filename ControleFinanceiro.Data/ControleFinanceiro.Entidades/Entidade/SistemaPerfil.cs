using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class SistemaPerfil
    {
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<SistemaUsuario> Usuarios { get; set; }
    }
}
