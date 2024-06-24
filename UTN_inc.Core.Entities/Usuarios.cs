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
        [Column("UsuarioId")]
        public int UsuarioId { get; set; }

        public string Nombre { get; set; }
        public string hash { get; set; }
        public int salt { get; set; }


        public override string ToString()
        {
            return $"ID usuario = [{UsuarioId}] Nombre = [{Nombre}]";
        }
    }
}
