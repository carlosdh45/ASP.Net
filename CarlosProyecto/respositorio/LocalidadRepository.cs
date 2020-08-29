using CarlosProyecto.clases;
using CarlosProyecto.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosProyecto.respositorio
{
    public class LocalidadRepository
    {
        public static t_Localidad DTOtoDB(Localidad localidad)
        {
            return new t_Localidad()
            {
                Id = localidad.Id,
                Departamento = localidad.Departamento,
                Ciudad = localidad.Ciudad
            };
        }

        public static Localidad DBTODTO(t_Localidad localidad)
        {
            return new Localidad()
            {
                Id = localidad.Id,
                Departamento = localidad.Departamento,
                Ciudad = localidad.Ciudad
            };
        }

        public static Localidad GetById(int id)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Localidad.ToList().SingleOrDefault(i => i.Id == id);
                Localidad newItem = new Localidad()
                {
                    Id = item.Id,
                    Ciudad = item.Ciudad,
                    Departamento = item.Departamento,
                };
                return newItem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool Add(Localidad usuarios)
        {
            try
            {
                var usuariosEntidad = DTOtoDB(usuarios);

                using (var db = new VEHICULOSEntities())
                {
                    db.t_Localidad.Add(usuariosEntidad);
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

        public static bool Remove(int id)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Localidad.ToList().SingleOrDefault(i => i.Id == id);
                db.t_Localidad.Remove(item);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public static bool UpdateById(Localidad newItem)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Localidad.ToList().SingleOrDefault(i => i.Id == newItem.Id);
                if (item != null)
                {
                    item.Id = newItem.Id;
                    item.Ciudad = newItem.Ciudad;
                    item.Departamento = newItem.Departamento;
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

        public static List<Localidad> GetAll()
        {
            var listaLocalidad = new List<t_Localidad>();

            using (var bd = new VEHICULOSEntities())
            {
                listaLocalidad = bd.t_Localidad.ToList();
            }

            return listaLocalidad.ConvertAll(x => new Localidad()
            {
                Id = x.Id,
                Departamento = x.Departamento,
                Ciudad = x.Ciudad
            });
        }
    }
}