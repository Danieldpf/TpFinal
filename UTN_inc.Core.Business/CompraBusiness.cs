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
    public class CompraBusiness
    {

        private readonly CompraRepository _compraRepository;
        private readonly ProductoRepository _productoRepository;
        private readonly Config _config;

        public CompraBusiness()
        {

            _compraRepository = new CompraRepository(_config);
            _productoRepository = new ProductoRepository(_config);
        }

        public string CrearCompra(int productoId, string fechaString, int cantidad, out string errorMessage)
        {
            var producto = _productoRepository.ProductoGet(productoId);

            if (producto == null)
            {
                errorMessage = "Producto no encontrado.";
                return null;
            }

            if (!DateTime.TryParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaCompra))
            {
                errorMessage = "Fecha ingresada no es válida.";
                return null;
            }

            DateTime fechaLimite = DateTime.Now.AddDays(-7);
            if (fechaCompra < fechaLimite || fechaCompra > DateTime.Now)
            {
                errorMessage = "Fecha fuera de rango.";
                return null;
            }

            if (cantidad <= 0)
            {
                errorMessage = "La compra no puede ser menor a 1.";
                return null;
            }

            var nuevaCompra = new Compra
            {
                fecha = fechaCompra,
                productoId = producto.Data.ProductoId,
                cantidad = cantidad,
                usuarioId = UsuarioGlobal.GetUsuario()
            };

            _compraRepository.CrearCompra(nuevaCompra);
            errorMessage = null;
            return "Compra creada exitosamente.";
        }
        public Compra ObtenerCompraBusiness(int compraId)
        {
            return _compraRepository.ObtenerCompra(compraId);
        }

        public List<Compra> ComprasDeUnUsuarioBusiness(int UsuarioID)
        {
            return _compraRepository.CompraDeUnUsuario(UsuarioID);
        }
    }
}
