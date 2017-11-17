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


namespace ControleFinanceiro.Start
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsultarPessoa1();
            Console.ReadKey();
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
