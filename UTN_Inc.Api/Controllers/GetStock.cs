using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;

namespace UTN_Inc.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetStock : Controller
    {

        [HttpGet("LeerPerfil/{userId}/ProductoID/{ProdId}")]
        public int get(int userId, int ProdId)
        {
            var userId1 = userId;
            var compraBussines = new CompraBusiness();
            var ventaBussines = new VentaBusiness();

            // Obtener el ID de usuario actual (no estoy seguro si esto es necesario aquí)
            userId1 = UsuarioGlobal.GetUsuario();

            var compras = compraBussines.ComprasDeUnUsuarioBusiness(userId);
            var ventas = ventaBussines.VentasDeUnUsuarioBusiness(userId);

            var prodID1 = ProdId;
            var result = 0;

            // Sumar las compras del producto específico
            foreach (var compra in compras)
            {
                if (compra.productoId == prodID1)
                {
                    result += compra.cantidad;
                }
            }

            // Restar las ventas del producto específico
            foreach (var venta in ventas)
            {
                if (venta.ProductoId == prodID1)
                {
                    result -= venta.Cantidad;
                }
            }

            return result;
        }
    }
}