using System;
using System.ComponentModel;

namespace ControleFinanceiro.Entidade.Enum
{
    public enum GrupoContabil
    {
        [Description("Conta Contábil do Grupo de Ativo")]
        Ativo = 1,

        [Description("Conta Contábil do Grupo de Passivo")]
        Passivo = 2,

        [Description("Conta Contábil do Grupo de Despesa")]
        Despesa = 3,

        [Description("Conta Contábil do Grupo de Receita")]
        Receita = 4,

        [Description("Conta Contábil do Grupo Transitória")]
        Transitoria = 5
    }
}
