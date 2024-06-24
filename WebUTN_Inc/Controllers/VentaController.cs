using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;
using WebUTN_Inc.Models;

namespace WebUTN_Inc.Controllers
{
    public class VentaController
        : Controller
    {
        private readonly ILogger<VentaController> _logger;
        private readonly ProductoBusiness _productoBusiness;
        private readonly VentaBusiness _ventaBusinnes;
        

        public VentaController(VentaBusiness ventaBusinnes,
                                ProductoBusiness productoBusiness,
                                ILogger<VentaController> logger)//recibe ejecuta y va a la accion que diga la ruta / ProductoController -> _productoBusiness = new ProductoBusiness(); -> IActionResult Index()
        {
            _logger = logger;
            _ventaBusinnes = ventaBusinnes;
            _productoBusiness = productoBusiness;
        }



        [HttpGet]
        public JsonResult VenderList()
        {
            var idUsuario = UsuarioGlobal.GetUsuario();
            var listaVenta = _ventaBusinnes.VentasDeUnUsuarioBusiness(idUsuario);

            return Json(listaVenta);
        }

        [HttpGet]
        public JsonResult ProductoList()
        {
            var listaProductos = _productoBusiness.GetAll();

            return Json(listaProductos);
        }

        [HttpPost]
        public JsonResult Vender(int productoId, int cantidad)
        {
            string errorMessage;
            var resultado = _ventaBusinnes.CrearVenta(productoId,  cantidad, out errorMessage);

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
