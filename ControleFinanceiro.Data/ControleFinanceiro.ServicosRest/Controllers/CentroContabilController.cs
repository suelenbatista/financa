using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ControleFinanceiro.Entidade.Entidade;
using ControleFinanceiro.ServicosRest.Models;

namespace ControleFinanceiro.ServicosRest.Controllers
{
    public class CentroContabilController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<CentroContabil> oListaCentroContabil = new CentroContabilModel().ObterCentroContabil();
                return Ok(oListaCentroContabil);
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
                CentroContabil oCentroContabil = new CentroContabilModel().ObterCentroContabilPorId(id);
                return Ok(oCentroContabil);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]CentroContabil centroContabil)
        {
            if (new CentroContabilModel().CadastrarCentroContabil(centroContabil))
            {
                var response = Request.CreateResponse<CentroContabil>(HttpStatusCode.Created, centroContabil);
                string uri = Url.Link("DefaultApi", new { id = centroContabil.IdCentro });
                response.Headers.Location = new Uri(uri);
                return response;
            }
            else
            {
                var response = Request.CreateResponse<CentroContabil>(HttpStatusCode.BadRequest, centroContabil);
                string uri = Url.Link("DefaultApi", new { id = 0 });
                response.Headers.Location = new Uri(uri);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]CentroContabil centroContabil)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                if (id != centroContabil.IdCentro)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                bool isAtualizado = new CentroContabilModel().AtualizarCentroContabil(id, centroContabil);

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

                bool isDeleted = new CentroContabilModel().DeletarCentroContabil(id);

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
