using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using WebUTN_Inc.Models;

namespace WebUTN_Inc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsuarioBusiness _usuarioBusinnes;

        public HomeController(UsuarioBusiness usuarioBusinnes,
            ILogger<HomeController> logger)
        {
            _logger = logger;
            _usuarioBusinnes= usuarioBusinnes;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Ventas()
        {
            return View();
        }

        public IActionResult Compras()
        {
            return View();

        }
        public class LoginData // Modelo para los datos de inicio de sesión
        {
            public string usuario { get; set; }
            public string contraseña { get; set; }
        }

        [HttpPost]
        public JsonResult Login([FromBody] LoginData data)
        {
            var usuario = data.usuario;
            var contraseña = data.contraseña;

            // Lógica de autenticación aquí
            bool isAuthenticated = AutenticarUsuario(usuario, contraseña);

            if (isAuthenticated)
            {
                return Json(new { success = true, message = "Usuario autenticado exitosamente." });
            }
            else
            {
                return Json(new { success = false, message = "Credenciales incorrectas." });
            }
        }
        private bool AutenticarUsuario(string usuario, string contraseña)
        {
            var usuarioLogeado = _usuarioBusinnes.ObtenerUnUsuariosBusiness(usuario);
            var contraseñaLogeada = usuarioLogeado.salt + contraseña;
            contraseñaLogeada = GeneradorHashSalt.GenerarHash(contraseñaLogeada);

            // Por ejemplo, validar contra una base de datos
            if (usuarioLogeado != null && contraseñaLogeada == usuarioLogeado.hash)
            {

                UsuarioGlobal.SetUsuario(usuarioLogeado.UsuarioId);
                return true;

            }
            return false;
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
