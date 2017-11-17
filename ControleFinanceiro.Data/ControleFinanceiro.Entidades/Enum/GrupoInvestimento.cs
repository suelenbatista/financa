
namespace ControleFinanceiro.Entidade.Enum
{
    using System;
    using System.ComponentModel;

    public enum GrupoInvestimento
    {
        [Description("Investimento em Tesouro Direto")]
        TD = 1,
        
        [Description("Investimento em Renda Fixa")]
        RF = 2,

        [Description("Investimento em Renda Variavel - Ações BM&F")]
        RV = 3
    }
}
