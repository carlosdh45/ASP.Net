using CarlosProyecto.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarlosProyecto.respositorio
{
    public class OrdenDetalleRepository
    {
        public static List<listaordenes> getAll()
        {


            using (var db = new VEHICULOSEntities())
            {

                var query = db.listaordenes.ToList();
                return query;
            }

        }

        public static listaordenes getbyId(int i)
        {


            using (var db = new VEHICULOSEntities())
            {

                var query = db.listaordenes.ToList().FirstOrDefault(q => q.ordenFactura == i);
                return query;
            }

        }
    }
}