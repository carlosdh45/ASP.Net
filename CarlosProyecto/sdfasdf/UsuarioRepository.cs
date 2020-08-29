    using Datos.Modelo;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{
  public  class UsuarioRepository
    {
        public static List<Usuarios> GetAllUsers()
        {
            try
            {
                var dbcon = new AUTOLOTEEntities1();
                var users = dbcon.t_Usuarios.ToList();
                var usersList = new List<Usuarios>();
                foreach (var user in users)
                {
                    usersList.Add(new Usuarios
                    {
                        Id = user.Id,
                        Usuario = user.Usuario,
                        TipoUsuario = user.TipoUsuario
                    });
                }
                return usersList != null ? usersList : null;
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }

        public static Usuarios GetById(int id)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Usuarios.ToList().SingleOrDefault(i => i.Id == id);
                Usuarios newItem = new Usuarios()
                {
                    Id = item.Id,
                    Usuario = item.Usuario,
                    TipoUsuario = item.TipoUsuario,
                };
                return newItem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static bool Remove(int id)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Usuarios.ToList().SingleOrDefault(i => i.Id == id);
                db.t_Usuarios.Remove(item);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public static bool UpdateById(Usuarios newItem)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Usuarios.ToList().SingleOrDefault(i => i.Id == newItem.Id);
                if (item != null)
                {
                    item.Id = newItem.Id;
                    item.Usuario = newItem.Usuario;
                    item.TipoUsuario = newItem.TipoUsuario;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }



        public static bool Add(Usuarios usuarios)
        {
            try
            {
                var usuariosEntidad = DTOtoDB(usuarios);

                using (var db = new AUTOLOTEEntities1())
                {
                    db.t_Usuarios.Add(usuariosEntidad);
                    db.SaveChanges();
                    return true;
                }

            }
           catch (Exception e)
            {
                throw e;
                return false;
            }
        }
        public static t_Usuarios DTOtoDB(Usuarios u)
        {
            return new t_Usuarios
            {
                Id = u.Id,
                Usuario = u.Usuario,
                TipoUsuario = u.TipoUsuario

            };
        }

        public static Usuarios DBtoDTO(t_Usuarios u)
        {
            return new Usuarios
            {
                Id = u.Id,
                Usuario = u.Usuario,
                TipoUsuario = u.TipoUsuario

            };

        }
    }
}
