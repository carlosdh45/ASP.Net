using CarlosProyecto.clases;
using CarlosProyecto.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosProyecto.respositorio
{
    public class OrdenRepository
    {

        public static Orden GetById(int id)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Orden.ToList().SingleOrDefault(i => i.Id == id);
                Orden newItem = new Orden()
                {
                    Id = item.Id,
                    CarroId = item.CarroId,
                    LocalizacionId = item.LocalizacionId,
                    UsuarioId = item.UsuarioId,
                };
                return newItem;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static List<Orden> GetAllOrden()
        {
            try
            {
                var dbcon = new VEHICULOSEntities();
                var cars = dbcon.t_Orden.ToList();
                var usersList = new List<Orden>();
                foreach (var car in cars)
                {
                    usersList.Add(new Orden
                    {
                        Id = car.Id,
                        CarroId = car.CarroId,
                        LocalizacionId = car.LocalizacionId,
                        UsuarioId = car.UsuarioId
                    }); ;
                }
                return usersList != null ? usersList : null;
            }
            catch (Exception e)
            {
                throw e;
                return null;
            }
        }


        public static bool Add(Orden usuarios)
        {
            try
            {
                var usuariosEntidad = DTOtoDB(usuarios);

                using (var db = new VEHICULOSEntities())
                {
                    db.t_Orden.Add(usuariosEntidad);
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


        public static t_Orden DTOtoDB(Orden car)
        {
            return new t_Orden
            {
                Id = car.Id,
                CarroId = car.CarroId,
                LocalizacionId = car.LocalizacionId,
                UsuarioId = car.UsuarioId

            };
        }


        public static bool Remove(int id)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Orden.ToList().SingleOrDefault(i => i.Id == id);
                db.t_Orden.Remove(item);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

        public static bool UpdateById(Orden newItem)
        {
            try
            {
                var db = new VEHICULOSEntities();
                var item = db.t_Orden.ToList().SingleOrDefault(i => i.Id == newItem.Id);
                if (item != null)
                {
                    item.Id = newItem.Id;
                    item.CarroId = newItem.CarroId;
                    item.LocalizacionId = newItem.LocalizacionId;
                    item.UsuarioId = newItem.UsuarioId;
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

        public static Orden DBtoDTO(t_Orden car)
        {
            return new Orden
            {
                Id = car.Id,
                CarroId = car.CarroId,
                LocalizacionId = car.LocalizacionId,
                UsuarioId = car.UsuarioId
            };
        }
    }
}