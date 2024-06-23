using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public string UsuarioId { get; set; }

        public string Nombre { get; set; }
        public string hash { get; set; }
        public string salt { get; set; }


        public override string ToString()
        {
            return $"ID usuario = [{UsuarioId}] Nombre = [{Nombre}]";
        }
    }
}
