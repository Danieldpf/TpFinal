using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    public class VentaRepository
    {
        private readonly Config _config;

        public VentaRepository(Config config)
        {
            _config = config;
        }




        public void CrearVenta(Venta nuevaVenta)
        {
            using (var db = new UTN_incContext(_config))
            {
                db.ventas.Add(nuevaVenta);
                db.SaveChanges();
            }
        }

        public Venta ObtenerVenta(int VentaId)
        {
            using (var db = new UTN_incContext(_config))
            {
                return db.ventas.Find(VentaId);
            }
        }


        public List<Venta> VentasDeUnUsuario(int UsuarioID)
        {
            using (var db = new UTN_incContext(_config))
            {
                var ventas = (from p in db.ventas
                                 where p.UsuarioId == UsuarioID
                              select p).ToList();
                return ventas;
            }
        }



    }
}
