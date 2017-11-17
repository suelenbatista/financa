using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class SistemaUsuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int IdPerfil { get; set; }
        
        public virtual SistemaPerfil PerfilUsuario { get; set; }
        public virtual ICollection<SistemaArquivo> ArquivosUsuario { get; set; }
    }
}
