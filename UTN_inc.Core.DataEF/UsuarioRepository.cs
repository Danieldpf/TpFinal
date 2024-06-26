﻿using System;
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
                var usuario = (from u in db.usuarios
                              where u.Nombre == nuevoUsuario.Nombre
                              select u).FirstOrDefault();

                if (usuario == null)
                {
                    db.usuarios.Add(nuevoUsuario);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Usuario Existente");
                    db.SaveChanges();
                }
                
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


        public void UsuarioDelete(int usuarioId)
        {
            var comprasUsuario = new CompraRepository(_config);
            var ventasUsuario = new VentaRepository(_config);



            using (var db = new UTN_incContext(_config))
            {
                var usuario = (from u in db.usuarios
                            where u.UsuarioId == usuarioId
                            select u).FirstOrDefault();
                
                if (usuario != null)
                {
                    db.usuarios.Remove(usuario);
                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("El usuario no existe");
                    db.SaveChanges();
                }
            }
        }
    }
}
