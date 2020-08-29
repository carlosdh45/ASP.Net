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
    public class usuarioController : RequestBaseController
    {
        [HttpPost]
        [ActionName("agregarusuario")]
        public HttpResponseMessage agregarusuario([FromBody] Usuarios U)
        {
            try
            {
                var exito = UsuarioRepository.Add(U);
                if (exito)
                {
                    return OkResponse("EXITO");
                }
                return ERRORResponse("ERROR");
            }
            catch (Exception e)
            {

                throw e.InnerException;
            }
        }


        [HttpGet]
        [ActionName("tenertodo")]
        public HttpResponseMessage tenertodo()
        {
            try
            {
                var usuarios = UsuarioRepository.GetAllUsers();
                return OkResponse(usuarios);
            }
            catch (Exception e)
            {
                return ERRORResponse_Ex(e.InnerException);
                throw e.InnerException;
            }
        }




        [HttpGet]
        [ActionName("listarconid")]
        public HttpResponseMessage listarconid([FromUri]int id)
        {
            try
            {
                var exito = UsuarioRepository.GetById(id);
                return OkResponse(exito);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [HttpGet]
        [ActionName("quitarconid")]
        public HttpResponseMessage quitarconid([FromUri]int id)
        {
            try
            {
                var exito = UsuarioRepository.Remove(id);
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
        [ActionName("editarocnid")]
        public HttpResponseMessage editarocnid([FromBody]Usuarios i)
        {
            try
            {
                var exito = UsuarioRepository.UpdateById(i);
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
    }
}
