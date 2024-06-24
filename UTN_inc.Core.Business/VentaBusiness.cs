using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.Business
{
    public class VentaBusiness
    {

        private readonly VentaRepository _ventaRepository;
        private readonly ProductoRepository _productoRepository;
        private readonly Config _config;

        public VentaBusiness()
        {

            _ventaRepository = new VentaRepository(_config);
            _productoRepository = new ProductoRepository(_config);
        }

        public string CrearVenta(int productoId, int cantidad, out string errorMessage)
        {
            var producto = _productoRepository.ProductoGet(productoId);

            if (producto == null)
            {
                errorMessage = "Producto no encontrado.";
                return null;
            }

            if (cantidad <= 0)
            {
                errorMessage = "La compra no puede ser menor a 1.";
                return null;
            }

            DateTime fechaVenta = DateTime.Now;

            var nuevaVenta = new Venta
            {
                Fecha = fechaVenta,
                ProductoId = producto.Data.ProductoId,
                Cantidad = cantidad,
                UsuarioId = UsuarioGlobal.GetUsuario()
            };

            _ventaRepository.CrearVenta(nuevaVenta);
            errorMessage = null;
            return "Compra creada exitosamente.";
        }
        public Venta ObtenerVentaBusiness(int VentaId)
        {
            return _ventaRepository.ObtenerVenta(VentaId);
        }


        public List<Venta> VentasDeUnUsuarioBusiness(int UsuarioID) 
        {
            return _ventaRepository.VentasDeUnUsuario(UsuarioID);
        }
    }
}
