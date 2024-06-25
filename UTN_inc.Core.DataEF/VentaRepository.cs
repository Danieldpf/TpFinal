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
            var producto = new ProductoRepository(_config);

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

        //Se Usa para la eliminacion del usuario
        public void VentasDeUnUsuarioDelete(int usuarioId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var ventas = (from v in db.ventas
                              where v.UsuarioId == usuarioId
                              select v).FirstOrDefault();

                if (ventas != null)
                {
                    db.ventas.Remove(ventas);
                    db.SaveChanges();
                }
                else
                {
                    db.SaveChanges();
                }
            }
        }

        
        public void EliminarVentaRepo(Venta venta)
        {
            using (var db = new UTN_incContext(_config))
            {
                db.ventas.Remove(venta);
                db.SaveChanges();
            }
        }

        //Eliminar venta de manera individual
        public void EliminarVentaRepo(int ventaiD)
        {
            using (var db = new UTN_incContext(_config))
            {
                var venta = (from v in db.ventas
                            where v.VentaId == ventaiD
                            select v).FirstOrDefault();

                if (venta != null)
                {
                    db.ventas.Remove(venta);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Esa venta no existe");
                    db.SaveChanges();
                }
                
            }
        }
    }
}
