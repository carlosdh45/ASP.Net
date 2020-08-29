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
    public class localizacionController : RequestBaseController
    {

        [HttpGet]
        [ActionName("listarconid")]
        public HttpResponseMessage listarconid([FromUri]int id)
        {
            try
            {
                var a = LocalidadRepository.GetById(id);
                return OkResponse(a);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        [ActionName("removerconid")]
        public HttpResponseMessage removerconid([FromUri]int id)
        {
            try
            {
                var exito = LocalidadRepository.Remove(id);
                if (exito)
                {
                    return OkResponse("EXITO");

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
        public HttpResponseMessage eidtarconid([FromBody]Localidad i)
        {
            try
            {
                var exito = LocalidadRepository.UpdateById(i);
                if (exito)
                {
                    return OkResponse("EXITO");

                }
                return OkResponse("ERROR");

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        [ActionName("listar")]
        public HttpResponseMessage listar()
        {
            try
            {
                var localidad = LocalidadRepository.GetAll();

                return OkResponse(localidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        [HttpPost]
        [ActionName("agregarlocalizacion")]
        public HttpResponseMessage agregarlocalizacion([FromBody]Localidad i)
        {
            try
            {
                var exito = LocalidadRepository.Add(i);
                if (exito)
                {
                    return OkResponse("EXITO");
                }
                return ERRORResponse("ERROR");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
