using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Entidade.Enum
{
    public enum StatusMovimento
    {
        [Description("Movimento com Status Pendente.")]
        Pendente,

        [Description("Movimento com Status Fechado.")]
        Fechado,

        [Description("Movimento com Status Cancelado.")]
        Cancelado
    }
}
