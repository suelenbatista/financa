using System;
using System.ComponentModel;

namespace ControleFinanceiro.Data.Enum
{
    public enum TipoTransacao
    {
        [Description("Baixa de Título")]
        Baixa = 1,

        [Description("Transferência Bancária")]
        Transferencia = 2
    }
}
