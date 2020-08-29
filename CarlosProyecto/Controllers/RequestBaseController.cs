using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosProyecto.Controllers
{
    public class RequestBaseController : ApiController
    {
        internal static readonly System.Net.Http.Formatting.MediaTypeFormatter DefaultFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter
        {
            UseDataContractJsonSerializer = false,
            SerializerSettings =
            {
                NullValueHandling = NullValueHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            }
        };
        internal System.Net.Http.HttpResponseMessage ERRORResponse(string message)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.StringContent(message);
            resp.StatusCode = System.Net.HttpStatusCode.BadRequest;

            return resp;
        }

        internal System.Net.Http.HttpResponseMessage ERRORResponse_Ex(Exception ex)
        {
            return ERRORResponse(ex.Message);
        }

        internal System.Net.Http.HttpResponseMessage OkResponse(object result)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.ObjectContent(result.GetType(), result, DefaultFormatter);
            resp.StatusCode = System.Net.HttpStatusCode.OK;
            return resp;
        }

        internal System.Net.Http.HttpResponseMessage Unauthorized(string message)
        {
            var resp = new System.Net.Http.HttpResponseMessage();
            resp.Content = new System.Net.Http.StringContent(message);
            resp.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return resp;
        }

        internal bool autenticar()
        {
            var token = "programacion4";
            var tokenrequest = Request.Headers.Authorization != null ? Request.Headers.Authorization.Parameter : "";
            if (tokenrequest  == token)
            {
                return true;
            }
            return false;
        }

    }
}

