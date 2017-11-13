using System;
using System.ComponentModel;

namespace ControleFinanceiro.Data.Enum
{
    public enum TipoMovimento
    {
        [Description("Contas à Pagar")]
        CP = 1,

        [Description("Contas à Receber")]
        CR = 2,

        [Description("Conta Corrente")]
        CC = 3,
    }
}
