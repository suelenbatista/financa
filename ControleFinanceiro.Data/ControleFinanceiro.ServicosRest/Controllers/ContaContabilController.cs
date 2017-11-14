using ControleFinanceiro.Entidades.Entidade;
using ControleFinanceiro.ServicosRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ControleFinanceiro.ServicosRest.Controllers
{
    public class ContaContabilController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<ContaContabil> oListaContaContabil = new ContaContabilModel().ObterContaContabil();
                return Ok(oListaContaContabil);
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
                ContaContabil oContaContabil = new ContaContabilModel().ObterContaContabilPorId(id);
                return Ok(oContaContabil);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]ContaContabil contaContabil)
        {
            if (new ContaContabilModel().CadastrarContaContabil(contaContabil))
            {
                var response = Request.CreateResponse<ContaContabil>(HttpStatusCode.Created, contaContabil);
                string uri = Url.Link("DefaultApi", new { id = contaContabil.IdContaContabil });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<ContaContabil>(HttpStatusCode.BadRequest, contaContabil);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]ContaContabil contaContabil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != contaContabil.IdContaContabil)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new ContaContabilModel().AtualizarContaContabil(id, contaContabil);

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

                bool isDeleted = new ContaContabilModel().DeletarContaContabil(id);

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
