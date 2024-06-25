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
    public class CompraRepository
    {
        private readonly Config _config;

        public CompraRepository(Config config)
        {
            _config = config;
        }


        public void CrearCompra(Compra nuevaCompra)
        {
            using (var db = new UTN_incContext(_config))
            {
                db.compras.Add(nuevaCompra);
                db.SaveChanges();
            }
        }

        public Compra ObtenerCompra(int compraId)
        {
            using (var db = new UTN_incContext(_config))
            {
                return db.compras.Find(compraId);
            }
        }

        public List<Compra> CompraDeUnUsuario(int UsuarioID)
        {
            using (var db = new UTN_incContext(_config))
            {
                var compras = (from p in db.compras
                              where p.usuarioId == UsuarioID
                              select p).ToList();
                return compras;
            }
        }

        //Elimina compras de un usuario
        public void ComprasDeUnUsuarioDelete(int usuarioId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var compra = from c in db.compras
                              where c.usuarioId == usuarioId
                              select c;

                /*
                 var compra = (from c in db.compras
                              where c.usuarioId == usuarioId
                              select c).FirstOrDefault();
                */

                if (compra != null)
                {
                    db.compras.RemoveRange(compra);
                    db.SaveChanges();
                }
                else
                {
                    db.SaveChanges();
                }
            }
        }

        public Compra BuscarCompraPorProducto(int productoId)
        {
            using (var db = new UTN_incContext(_config))
            {
                //return db.compras.Find(productoId);
                var comp = (from p in db.compras
                            where p.productoId == productoId
                            select p).FirstOrDefault();

                return comp;
            }

        }

        //Elimina compra individual
        public void EliminarCompraRepo(int CompraiD)
        {
            using (var db = new UTN_incContext(_config))
            {
                var compra = (from c in db.compras
                             where c.compraId == CompraiD
                             select c).FirstOrDefault();

                if (compra != null)
                {
                    db.compras.Remove(compra);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Esa compra no existe");
                    db.SaveChanges();
                }

            }
        }

    }
}

