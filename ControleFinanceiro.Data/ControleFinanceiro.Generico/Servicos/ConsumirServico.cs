using ControleFinanceiro.Entidade.Entidade;
using ControleFinanceiro.Entidade.Enum;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ControleFinanceiro.Generics.Servicos
{
    public class ConsumirServico
    {
        private WebClient WebServico;
        private DateTime DataRequisicao;
        private DateTime DataRetorno;
        private Boolean Status;
        private HttpStatusCode CodigoStatus;
        private String MensagemStatus;
        private String URLRequest;

        public ConsumirServico(string urlRequest)
        {
            WebServico = new WebClient();
            WebServico.Encoding = Encoding.UTF8;
            WebServico.Headers.Add("Content-Type:application/json");
            WebServico.Headers.Add("Accept:application/json");
            URLRequest = urlRequest;
        }

        public string GetServico()
        {
            string result = WebServico.DownloadString(URLRequest);
            return result;
        }

        public string PostServico(string strJSON)
        {
            string result = WebServico.UploadString(URLRequest, strJSON);
            return result;
        }

        public int ObterStatusCodigo()
        {
            return (int)CodigoStatus;
        }

        public bool ObterStatus()
        {
            return Status;
        }

        public string ObterStatusMensagem()
        {
            return MensagemStatus;
        }

        public async Task<T> GetAsync<T>(string endereco) where T : new()
        {
            T objeto = new T();

            try
            {
                DataRequisicao = DateTime.Now;

                RestClient client = new RestClient(endereco);
                RestRequest request = new RestRequest(Method.GET);

                request.AddHeader("cache-control", "no-cache");

                Task<IRestResponse<T>> t = client.ExecuteTaskAsync<T>(request);
                t.Wait();
                IRestResponse<T> restResponse = await t;

                DataRetorno = DateTime.Now;

                objeto = restResponse.Data;

                Status = (restResponse.StatusCode == HttpStatusCode.OK) || (restResponse.StatusCode == HttpStatusCode.Created);
                CodigoStatus = restResponse.StatusCode;
                MensagemStatus = restResponse.StatusDescription;

                return objeto;
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<T> PostAsync<T>(string objetoJson) where T : new()
        {
            //string autenticacaoDados;
            T objeto = new T();

            try
            {
                DataRequisicao = DateTime.Now;

                RestClient client = new RestClient(URLRequest);
                RestRequest request = new RestRequest(Method.POST);

                //autenticacaoDados = string.Format("{0} {1}", token.token_type, token.access_token);

                request.AddHeader("cache-control", "no-cache");
                //request.AddHeader("authorization", autenticacaoDados);
                request.AddHeader("content-type", "application/json");
                request.AddParameter("application/json", objetoJson, ParameterType.RequestBody);

                Task<IRestResponse<T>> t = client.ExecuteTaskAsync<T>(request);
                t.Wait();
                IRestResponse<T> restResponse = await t;

                DataRetorno = DateTime.Now;

                objeto = restResponse.Data;

                Status = (restResponse.StatusCode == HttpStatusCode.OK) || (restResponse.StatusCode == HttpStatusCode.Created);
                CodigoStatus = restResponse.StatusCode;
                MensagemStatus = restResponse.StatusDescription;

                return objeto;
            }
            catch (WebException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static List<Pessoa> Get()
        {
            List<Pessoa> oListaPessoa = new List<Pessoa>();
            string content = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:9801/api/Pessoa/");

            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            oListaPessoa = JsonConvert.DeserializeObject<List<Pessoa>>(content);

            return oListaPessoa;
        }

    }
}
