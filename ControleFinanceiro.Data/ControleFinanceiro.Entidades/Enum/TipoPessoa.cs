using System.ComponentModel;

namespace ControleFinanceiro.Entidades.Enum
{
    public enum TipoPessoa
    {
        [Description("Tipo de Pessoa Fisica")]
        Fisica = 0,

        [Description("Tipo de Pessoa Juridica")]
        Juridica = 1
    }
}
