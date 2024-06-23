using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UTN_inc.Core.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Column("Nombre")]
        public string NombreCategoria { get; set; }

        public virtual List<Producto> listaProductos { get; set; } = new List<Producto>();
        //public List<Producto> listaProductos { get; set; }

        public override string ToString()
        {
            return $"[ID ={CategoriaId}] [Nombre = {NombreCategoria}]";
        }

        
    }
}
