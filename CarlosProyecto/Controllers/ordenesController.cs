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
    public class ordenesController : RequestBaseController
    {
        [HttpPost]
        [ActionName("agregarorden")]
        public HttpResponseMessage agregarorden([FromBody] Orden U)
        {
            try
            {
                var exito = OrdenRepository.Add(U);
                if (exito)
                {
                    return OkResponse("OK");
                }
                return ERRORResponse("MALO");
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }


        [HttpGet]
        [ActionName("listarordenes")]
        public HttpResponseMessage listarordenes()
        {
            try
            {
                var usuarios = OrdenRepository.GetAllOrden();
                return OkResponse(usuarios);
            }
            catch (Exception e)
            {
                return ERRORResponse_Ex(e.InnerException);
                throw e.InnerException;
            }
        }


        [HttpGet]
        [ActionName("actualizarporId")]
        public HttpResponseMessage actualizarporid([FromUri]int id)
        {
            try
            {
                var exito = OrdenRepository.GetById(id);
                return OkResponse(exito);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        [ActionName("removerpoid")]
        public HttpResponseMessage removerpoid([FromUri]int id)
        {
            try
            {
                var exito = OrdenRepository.Remove(id);
                if (exito)
                {
                    return OkResponse("ok");

                }
                return OkResponse("error");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpPost]
        [ActionName("actualizarporid")]
        public HttpResponseMessage actualizarporid([FromBody]Orden i)
        {
            try
            {
                var exito = OrdenRepository.UpdateById(i);
                if (exito)
                {
                    return OkResponse("ok");

                }
                return OkResponse("malo");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        [ActionName("tenerordenesdetalles")]
        public HttpResponseMessage tenerordenesdetlles()
        {
            try
            {
                var a = OrdenDetalleRepository.getAll();
                return OkResponse(a);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
    }
}
