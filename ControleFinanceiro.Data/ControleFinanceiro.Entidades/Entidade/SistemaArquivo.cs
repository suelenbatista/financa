using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidade.Entidade
{
    public class SistemaArquivo
    {
        public int IdArquivo { get; set; }
        public string Descricao { get; set; }
        public string NomeArquivo { get; set; }
        public string Diretorio { get; set; }
        public string DiretorioVirtual { get; set; }
        public string Extensao { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public virtual SistemaUsuario UsuarioSistema { get; set; }
    }
}
