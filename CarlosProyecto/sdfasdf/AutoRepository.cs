using Datos.Modelo;
using Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{
    public class AutoRepository
    {


        public static List<Auto> GetAllCars()
            {
            try {
                var dbcon = new AUTOLOTEEntities1();
                var cars = dbcon.t_Auto.ToList();
                var usersList = new List<Auto>();
                foreach ( var car in cars)
                {
                    usersList.Add(new Auto { 
                        Id = car.Id,
                        TipoAutomovil = car.TipoAutomovil,
                        Marca = car.Marca,
                        Modelo = car.Modelo,
                        TipoCombustible = car.TipoCombustible,
                        Cilindraje = car.Cilindraje,
                        Transmision = car.Transmision,
                        Condiciones = car.Condiciones,
                        Atributos = car.Atributos,
                    });
                }
                return usersList != null ? usersList : null;
            }
            catch (Exception e)
            {
                throw e.InnerException;
                return null;
            }
            }


        public static t_Auto DTOtoDB(Auto car)
        {
            return new t_Auto
            {
                Id = car.Id,
                TipoAutomovil = car.TipoAutomovil,
                Marca = car.Marca,
                Modelo = car.Modelo,
                TipoCombustible = car.TipoCombustible,
                Cilindraje = car.Cilindraje,
                Transmision = car.Transmision,
                Condiciones = car.Condiciones,
                Atributos = car.Atributos,

            };
        }

        public static Auto DBtoDTO(t_Auto car)
        {
            return new Auto
            {
                Id = car.Id,
                TipoAutomovil = car.TipoAutomovil,
                Marca = car.Marca,
                Modelo = car.Modelo,
                TipoCombustible = car.TipoCombustible,
                Cilindraje = car.Cilindraje,
                Transmision = car.Transmision,
                Condiciones = car.Condiciones,
                Atributos = car.Atributos,

            };

        }

        public static Auto GetById(int id)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Auto.ToList().SingleOrDefault(i => i.Id == id);
                Auto newItem = new Auto()
                {
                    Id = item.Id,
                    Marca = item.Marca,
                    Modelo = item.Modelo,
                    Cilindraje = item.Cilindraje,
                    TipoAutomovil = item.TipoAutomovil,
                    Condiciones = item.Condiciones,
                    TipoCombustible = item.TipoCombustible,
                    Transmision = item.Transmision,
                    Atributos = item.Atributos,
                };
                return newItem;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        public static bool Add(Auto usuarios)
        {
            try
            {
                var usuariosEntidad = DTOtoDB(usuarios);

                using (var db = new AUTOLOTEEntities1())
                {
                    db.t_Auto.Add(usuariosEntidad);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception e)
            {
                throw e.InnerException;
                return false;
            }
        }

        public static bool Remove(int id)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Auto.ToList().SingleOrDefault(i => i.Id == id);
                db.t_Auto.Remove(item);
                db.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw e.InnerException;
                return false;
            }
        }

        public static bool UpdateById(Auto newItem)
        {
            try
            {
                var db = new AUTOLOTEEntities1();
                var item = db.t_Auto.ToList().SingleOrDefault(i => i.Id == newItem.Id);
                if (item != null)
                {
                    item.Id = newItem.Id;
                    item.Marca = newItem.Marca;
                    item.Modelo = newItem.Modelo;
                    item.Cilindraje = newItem.Cilindraje;
                    item.TipoAutomovil = newItem.TipoAutomovil;
                    item.Condiciones = newItem.Condiciones;
                    item.TipoCombustible = newItem.TipoCombustible;
                    item.Transmision = newItem.Transmision;
                    item.Atributos = newItem.Atributos;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e.InnerException;
                return false;
            }
        }




    }
}
