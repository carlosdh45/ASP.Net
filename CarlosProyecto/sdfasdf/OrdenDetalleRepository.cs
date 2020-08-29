using Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repository
{
   public class OrdenDetalleRepository
    {
    public static List<getAllOrdenDetalle> getAll()
        {


            using (var db = new AUTOLOTEEntities1())
            {

                var query = db.getAllOrdenDetalle.ToList();
                return query;
            }

        }

        public static getAllOrdenDetalle getbyId(int i)
        {


            using (var db = new AUTOLOTEEntities1())
            {

                var query = db.getAllOrdenDetalle.ToList().FirstOrDefault(q=> q.id_Orden == i);
                return query;
            }

        }
    }
}
