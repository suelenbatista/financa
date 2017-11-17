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
    public class MovimentoRateioRateioController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<MovimentoRateio> oListaMovimentoRateio = new MovimentoRateioModel().ObterMovimentoRateio();
                return Ok(oListaMovimentoRateio);
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
                MovimentoRateio oMovimentoRateio = new MovimentoRateioModel().ObterMovimentoRateioPorId(id);
                return Ok(oMovimentoRateio);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]MovimentoRateio MovimentoRateio)
        {
            if (new MovimentoRateioModel().CadastrarMovimentoRateio(MovimentoRateio))
            {
                var response = Request.CreateResponse<MovimentoRateio>(HttpStatusCode.Created, MovimentoRateio);
                string uri = Url.Link("DefaultApi", new { id = MovimentoRateio.IdMovRateio });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<MovimentoRateio>(HttpStatusCode.BadRequest, MovimentoRateio);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]MovimentoRateio MovimentoRateio)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != MovimentoRateio.IdMovRateio)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new MovimentoRateioModel().AtualizarMovimentoRateio(id, MovimentoRateio);

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

                bool isDeleted = new MovimentoRateioModel().DeletarMovimentoRateio(id);

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
