using ControleFinanceiro.Entidade.Enum;
using ControleFinanceiro.Dominio.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControleFinanceiro.ServicosRest.Models;

namespace ControleFinanceiro.ServicosRest.Controllers
{
    public class PessoaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try 
            {	        
                List<Pessoa> oListaPessoas = new PessoaModel().ObterPessoas();
                return Ok(oListaPessoas);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Pessoa oPessoa = new PessoaModel().ObterPessoaPorId(id);
                return Ok(oPessoa);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Pessoa pessoa)
        {
            if (new PessoaModel().CadastrarPessoa(pessoa))
            {
                var response = Request.CreateResponse<Pessoa>(HttpStatusCode.Created, pessoa);
                string uri = Url.Link("DefaultApi", new { id = pessoa.IdPessoa });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<Pessoa>(HttpStatusCode.BadRequest, pessoa);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Pessoa pessoa)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != pessoa.IdPessoa)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new PessoaModel().AtualizarPessoa(id, pessoa);

                if (!isAtualizado)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message.ToString());
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                bool isDeleted = new PessoaModel().DeletarPessoa(id);

                if (!isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message.ToString());
            }
        }
    }
}
