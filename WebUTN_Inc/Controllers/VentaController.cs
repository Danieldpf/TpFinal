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


        public class AyudaProductos // Modelo para los datos de inicio de sesión
        {
            public string Nombre { get; set; }
            public int ProductoId { get; set; }
        }


        public class InputVentaModelo// modelo de los datos
        {
            public int IdProducto { get; set; }
            public int Cantidad { get; set; }
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

            var listaProductosProcesados = new List<AyudaProductos>();
            //var listaProductosProcesados = new List<string>();
            var listaProductos = _productoBusiness.GetAll();

            foreach (var producto in listaProductos.Data) {
                var ayudaProducto=new AyudaProductos
                {
                    Nombre = producto.Nombre,
                    ProductoId=producto.ProductoId
                };
                listaProductosProcesados.Add(ayudaProducto);            
            }
            var JsonResult = new JsonResult(listaProductosProcesados);


            return Json(JsonResult);
        }

        [HttpPost]
        public JsonResult Vender([FromBody] InputVentaModelo datos)//parcea lo que recibe del body "un json" a un objeto
        {
            string errorMessage;
            var resultado = _ventaBusinnes.CrearVenta(datos.IdProducto, datos.Cantidad, out errorMessage);//recibe modelo Input

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
