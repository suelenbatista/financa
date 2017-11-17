using ControleFinanceiro.Entidade.Entidade;
using ControleFinanceiro.ServicosRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControleFinanceiro.ServicosRest.Controllers
{
    public class ContaBancariaController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<ContaBancaria> oListaContaBancaria = new ContaBancariaModel().ObterContaBancaria();
                return Ok(oListaContaBancaria);
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
                ContaBancaria oContaBancaria = new ContaBancariaModel().ObterContaBancariaPorId(id);
                return Ok(oContaBancaria);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]ContaBancaria ContaBancaria)
        {
            if (new ContaBancariaModel().CadastrarContaBancaria(ContaBancaria))
            {
                var response = Request.CreateResponse<ContaBancaria>(HttpStatusCode.Created, ContaBancaria);
                string uri = Url.Link("DefaultApi", new { id = ContaBancaria.IdConta });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<ContaBancaria>(HttpStatusCode.BadRequest, ContaBancaria);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]ContaBancaria ContaBancaria)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != ContaBancaria.IdConta)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new ContaBancariaModel().AtualizarContaBancaria(id, ContaBancaria);

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

                bool isDeleted = new ContaBancariaModel().DeletarContaBancaria(id);

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
