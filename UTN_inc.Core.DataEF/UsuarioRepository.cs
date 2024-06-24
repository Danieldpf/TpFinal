using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    public class UsuarioRepository
    {
        private readonly Config _config;

        public UsuarioRepository(Config config)
        {
            _config = config;
        }



        public void CrearUsuarioRepo(Usuarios nuevoUsuario)
        {
            using (var db = new UTN_incContext(_config))
            {
                var usuario = from u in db.usuarios
                              where u.Nombre == nuevoUsuario.Nombre
                              select u;

                db.usuarios.Add(nuevoUsuario);
                db.SaveChanges();
            }
        }

        public List<Usuarios> ObtenerUsuariosRepo()
        {
            using (var db = new UTN_incContext(_config))
            {
                var Listusuarios = (from p in db.usuarios
                            select p).ToList();

                return Listusuarios;
            }
        }

        public Usuarios ObtenerUnUsuariosRepo(string nombre)
        {
            using (var db = new UTN_incContext(_config))
            {
                var usuario = (from p in db.usuarios
                               where p.Nombre == nombre
                               select p).FirstOrDefault();
                return usuario;
            }
        }
    }
}
