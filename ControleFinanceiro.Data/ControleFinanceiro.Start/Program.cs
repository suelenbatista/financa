using ControleFinanceiro.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using ControleFinanceiro.Entidade.Entidade;
using ControleFinanceiro.Generics.Servicos;
using ControleFinanceiro.Generics.Util;
using System.Text.RegularExpressions;


namespace ControleFinanceiro.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConsultarPessoa1();

            //string campoAuxiliar = "RFQA;351881086765599;1;1.499,00;29,70";
            string campoAuxiliar = "RFQA;358982060286835;10;1499,00;35,99";
            Console.WriteLine(campoAuxiliar);
            decimal valorPremio = ObtemValorProduto(campoAuxiliar);
            Console.WriteLine(valorPremio);


            campoAuxiliar = "RFQA;358982060286835;10";
            Console.WriteLine(campoAuxiliar);
            valorPremio = ObtemValorProduto(campoAuxiliar);
            Console.WriteLine(valorPremio);

            campoAuxiliar = "QA|358982060286835|10|2199,00|543,99";
            Console.WriteLine(campoAuxiliar);
            valorPremio = ObtemValorProduto(campoAuxiliar);
            Console.WriteLine(valorPremio);
            
            Console.ReadKey();
        }


        public static decimal ObtemValorProduto(string campoAuxiliar)
        {
            try
            {
                decimal valorPremio = 0M;

                /* 1ª  Busca - Tenta identificar pelo separador | */
                var objUnificado = campoAuxiliar.Split('|');
                if (objUnificado != null)
                {
                    if (objUnificado.Length >= 4)
                    {
                        valorPremio = (string.IsNullOrWhiteSpace(objUnificado[4]) ? 0M : Convert.ToDecimal(objUnificado[4].ToString()));
                    }
                }
                if (valorPremio > 0) return valorPremio;

                /* 2ª  Busca - Tenta identificar pelo separador ; */
                var objLegado = campoAuxiliar.Split(';');
                if (objLegado != null)
                {
                    if (objLegado.Length >= 4)
                    {
                        valorPremio = (string.IsNullOrWhiteSpace(objLegado[4]) ? 0M : Convert.ToDecimal(objLegado[4].ToString()));
                    }
                }
                if (valorPremio > 0) return valorPremio;


                /* 3ª  Busca - Tenta identificar pelo separador ; via REGEX */
                string[] aux = Regex.Split(campoAuxiliar, @";");
                if (aux != null)
                {
                    if (aux.Length >= 4)
                    {
                        valorPremio = (string.IsNullOrWhiteSpace(aux[4]) ? 0M : Convert.ToDecimal(aux[4].ToString()));
                    }
                }

                return valorPremio;
            }
            catch (Exception ex)
            {
                //Log.ErrorFormat("Erro no método ObtemValorProduto. Mensagem {1}.", ex.Message.ToString());
                return 0M;
            }
        }

        private static void CadastrarPessoaAsync()
        {
            var oservico = new ConsumirServico("http://localhost:9801/api/Pessoa/");
            Pessoa oPessoa;

            oPessoa = new Pessoa
            {
                Tipo = Entidade.Enum.TipoPessoa.Fisica,
                Nome = "Rosimeire da Silva",
                Documento = "0980989008",
                DataCadastro = DateTime.Now,
                IdPessoa = 0,
            };

            var conteudo = ObjetToJson.ConverterParaJson(oPessoa);
            var result = oservico.PostAsync<Pessoa>(conteudo);
        }

        private static List<Pessoa> ConsultarPessoa1()
        {

            var novaListaPessoa = ConsumirServico.Get();

            foreach (var item in novaListaPessoa)
            {
                Console.WriteLine();
                Console.WriteLine("{0}\t{1}\t{2}", item.IdPessoa, item.Nome, item.Tipo);
            }
            return novaListaPessoa;
        }

        private static void ConsultarPessoaBanco()
        {
            List<Pessoa> oListaPessoa = new List<Pessoa>();

            using (var dbContexto = new DbFinancaContext())
            {
                oListaPessoa = dbContexto.Pessoa.ToList();
            }

            foreach (var item in oListaPessoa)
            {
                Console.WriteLine("{0}\t{1}\t{2}", item.IdPessoa, item.Nome, item.Tipo);
            }
        }

        private static void CadatrarPessoaBanco()
        {
            var db = new DbFinancaContext();

            using (var dbContexto = new DbFinancaContext())
            {
                dbContexto.Pessoa.ToList();
            }

            var pessoa = new Pessoa
            {
                Nome = "Laís Moreira",
                Tipo = Entidade.Enum.TipoPessoa.Fisica,
                Documento = "39338667820",
                DataCadastro = DateTime.Now
            };

            db.Pessoa.Add(pessoa);
            db.SaveChanges();

            var pessoas = db.Pessoa.ToList();

            Console.WriteLine("Lista de Todas as pessoas existentes na base!");
            foreach (Pessoa item in pessoas)
            {
                Console.WriteLine(item.Nome.ToString());
            }

            Console.ReadKey();
        }
    }
}
