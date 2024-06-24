using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Configuracion
{
    public class UsuarioGlobal
    {
        private static int UsuarioID;

        public static void SetUsuario(int id) 
        {
            UsuarioID = id;
        }

        public static int GetUsuario()
        {
            return UsuarioID;
        }

        public static void BorrarUsuario()
        {
            UsuarioID = -1;
        }
    }
}
