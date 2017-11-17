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
    public class InvestimentoMovController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<InvestimentoMov> oListaInvestimentoMov = new InvestimentoMovModel().ObterInvestimentoMov();
                return Ok(oListaInvestimentoMov);
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
                InvestimentoMov oInvestimentoMov = new InvestimentoMovModel().ObterInvestimentoMovPorId(id);
                return Ok(oInvestimentoMov);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]InvestimentoMov InvestimentoMov)
        {
            if (new InvestimentoMovModel().CadastrarInvestimentoMov(InvestimentoMov))
            {
                var response = Request.CreateResponse<InvestimentoMov>(HttpStatusCode.Created, InvestimentoMov);
                string uri = Url.Link("DefaultApi", new { id = InvestimentoMov.IdInvestMov });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<InvestimentoMov>(HttpStatusCode.BadRequest, InvestimentoMov);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]InvestimentoMov InvestimentoMov)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != InvestimentoMov.IdInvestMov)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new InvestimentoMovModel().AtualizarInvestimentoMov(id, InvestimentoMov);

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

                bool isDeleted = new InvestimentoMovModel().DeletarInvestimentoMov(id);

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
