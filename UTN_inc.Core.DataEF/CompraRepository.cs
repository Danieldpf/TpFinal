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
    }
}

