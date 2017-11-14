﻿using ControleFinanceiro.Data.Context;
using ControleFinanceiro.Entidade.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Dominio.Servico
{
    public class ContaBancariaServico: ServicoBase<ContaBancaria>
    {
        public ContaBancariaServico(DbFinancaContext oDbContexto): base(oDbContexto)
        {
        }
    }
}
