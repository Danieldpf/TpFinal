using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.Business
{
    public class UsuarioBusiness
    {

        private readonly UsuarioRepository _usuarioRepository;

        private readonly Config _config;

        public UsuarioBusiness()
        {
            _usuarioRepository = new UsuarioRepository(_config);
        }

        public UsuarioBusiness(UsuarioRepository productoRepository)
        {

            _usuarioRepository = productoRepository;
        }

        public void CrearUsuarioBusiness(Usuarios nuevoUsuario) 
        {
            _usuarioRepository.CrearUsuarioRepo(nuevoUsuario);
        }

        public List<Usuarios> ObtenerUsuariosBusiness()
        {
            return _usuarioRepository.ObtenerUsuariosRepo();
        }


        public Usuarios ObtenerUnUsuariosBusiness(string nombre) 
        {
            var usuario = _usuarioRepository.ObtenerUnUsuariosRepo(nombre);
            if (usuario == null)
            {
                Console.WriteLine("Usuario o contraseña Invalido");
                return null;
            }

            return usuario;
        }

    }
}
