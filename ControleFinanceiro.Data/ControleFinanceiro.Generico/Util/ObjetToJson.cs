
namespace ControleFinanceiro.Generics.Util
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using Newtonsoft.Json;

    public static class ObjetToJson
    {
        public static string ConverterParaJson<TEntidade>(TEntidade objeto) where TEntidade : class
        {
            return JsonConvert.SerializeObject(objeto);
        }
    }
}
