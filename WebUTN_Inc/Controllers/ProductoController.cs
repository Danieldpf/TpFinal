using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTN_inc.Core.Business;
using WebUTN_Inc.Models;

namespace WebUTN_Inc.Controllers
{
    public class ProductoController : Controller    
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly ProductoBusiness _productoBusiness;

        public ProductoController(ProductoBusiness productoBusiness,//inyeccion
                                    ILogger<ProductoController> logger)//recibe ejecuta y va a la accion que diga la ruta / ProductoController -> _productoBusiness = new ProductoBusiness(); -> IActionResult Index()
        {
            _logger = logger;
            _productoBusiness = productoBusiness;


            //Todo Inyeccion de dependencias
            //_productoBusiness = new ProductoBusiness();// en el constructor ya crea para no estar creando aca a cada rato
            //hay que preveer que esto no se este generando constantemente porque con cada request se genera uno lo ideal seria que se genere una sola vez
        }
        //Sabe a que vista ir por nombre
        public IActionResult Index()
        {   //esto es el modelo / el modelo no simpre tiene que estar en la carpeta modelo  / entities es el modelo
            var productos = _productoBusiness.GetAll();// y aca se encarga la capa de negocios y la de datos de traer de donde tenga que hacerlo
            return View(productos);//otra sobrecarga que maneja View es que se le puede pasar el modelo
        }

        public IActionResult Index2()
        {   //esto es el modelo / el modelo no simpre tiene que estar en la carpeta modelo  / entities es el modelo
            var productos = _productoBusiness.GetProducto(1);
            return View(_productoBusiness.Update(productos));//otra sobrecarga que maneja View es que se le puede pasar el modelo
        }

        //estos ruteos se pueden comentar no afecta en nada. si alguno de los 2 da error comentar o borrar
        [Route("/detalles-internos")]//de esta manera soporta que se los llame con estos nombres en la web / es una menera de definir rutas
        [Route("/detalles")]
        public IActionResult Detalles()// el controlador maneja lo que responde al servidor web/ la app
        {
            return View("DetallesInternos");//el metodo view tiene una sobreCarga que nos permite pasarle el nombre de la vista 
        }



        /************************************************
         Estos 2 metodos vinieron con la creacion del proyecto
         los comente nomas porque no se si lo van a necesitar
         mas adelante
         ***********************************************/

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
