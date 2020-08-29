using CarlosProyecto.clases;
using CarlosProyecto.respositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarlosProyecto.Controllers
{
    public class vehiculoController : RequestBaseController
    {
        [HttpGet]
        [ActionName("obtenerporid")]
        public HttpResponseMessage obtenerpoid([FromUri]int id)
        {
            try
            {
                if (!autenticar())
                {
                    return Unauthorized("sinpermisos");
                }
                var OK = AutoRepository.GetById(id);
                return OkResponse(OK);
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        [HttpGet]
        [ActionName("removerconid")]
        public HttpResponseMessage removerconid([FromUri]int id)
        {
            try
            {
                var OK = AutoRepository.Remove(id);
                if (OK)
                {
                    if (!autenticar())
                    {
                        return Unauthorized("sinpermisos");
                    }
                    return OkResponse("OK");

                }
                return OkResponse("ERROR");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        [ActionName("eidtarconid")]
        public HttpResponseMessage eidtarconid([FromBody]Auto i)
        {
            try
            {
                var OK = AutoRepository.UpdateById(i);
                if (OK)
                {
                    if (!autenticar())
                    {
                        return Unauthorized("sinpermisos");
                    }
                    return OkResponse("OK");

                }
                return OkResponse("ERROR");

            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }

        [HttpGet]
        [ActionName("listartodos")]
        public HttpResponseMessage listartodos()
        {
            try
            {
                if (!autenticar())
                {
                    return Unauthorized("sinpermisos");
                }
                var Auto = AutoRepository.GetAllCars();

                return OkResponse(Auto);
            }
            catch (Exception e)
            {
                return ERRORResponse_Ex(e);
                throw e.InnerException;
            }
        }



        [HttpPost]
        [ActionName("agregarcarro")]
        public HttpResponseMessage listartodos([FromBody]Auto i)
        {
            try
            {
                if (!autenticar())
                {
                    return Unauthorized("sinpermisos");
                }
                var OK = AutoRepository.Add(i);
                if (OK)
                {
                    return OkResponse("OK");
                }
                return ERRORResponse("ERROR");
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}

