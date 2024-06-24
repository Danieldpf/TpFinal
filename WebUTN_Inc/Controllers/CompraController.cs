using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;
using WebUTN_Inc.Models;

namespace WebUTN_Inc.Controllers
{
    public class CompraController
        : Controller
    {
        private readonly ILogger<CompraController> _logger;
        private readonly ProductoBusiness _productoBusiness;
        private readonly CategoriaBusiness _categoriaBusiness;
        private readonly CompraBusiness _compraBusinnes;

        public CompraController(CompraBusiness compraBusinnes,
                                ProductoBusiness productoBusiness,
                                ILogger<CompraController> logger)//recibe ejecuta y va a la accion que diga la ruta / ProductoController -> _productoBusiness = new ProductoBusiness(); -> IActionResult Index()
        {
            _logger = logger;
            _compraBusinnes = compraBusinnes;
            _productoBusiness = productoBusiness;
        }



        [HttpGet]
        public JsonResult ComprasList()
        {
            var idUsuario = UsuarioGlobal.GetUsuario();
            var listaCompra = _compraBusinnes.ComprasDeUnUsuarioBusiness(idUsuario);

            return Json(listaCompra);
        }

        [HttpGet]
        public JsonResult ProductoList()
        {
            var listaProductos = _productoBusiness.GetAll();

            return Json(listaProductos);
        }

        [HttpPost]
        public JsonResult Comprar(int productoId, string fecha, int cantidad)
        {
            string errorMessage;
            var resultado = _compraBusinnes.CrearCompra(productoId, fecha, cantidad, out errorMessage);

            if (resultado != null)
            {
                return Json(new { success = true, message = resultado });
            }
            else
            {
                return Json(new { success = false, message = errorMessage });
            }
        }



    }
}
