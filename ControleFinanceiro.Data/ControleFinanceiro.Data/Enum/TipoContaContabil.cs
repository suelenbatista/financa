using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Data.Enum
{
    public enum TipoContaContabil
    {
        [Description("Conta Contábil do Tipo Patrimonial")]
        Patrimonial = 1,

        [Description("Conta Contábil do Tipo Resultado")]
        Resultado = 2
    }
}
