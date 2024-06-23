using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{
    [Table("Compra")]
    public class Compra
    {
        [Key]
        public int compraId { get; set; }
        [Column("Fecha")]
        public DateTime fecha { get; set; }
        
        [ForeignKey("Producto")]
        [Column("ProductoId")]
        public int productoId { get; set; }
        [Column("Cantidad")]
        public int cantidad { get; set; }
        [ForeignKey("Usuario")]
        [Column("UsuarioId")]
        public int usuarioId { get; set; }

        public override string ToString()
        {
            return $"[ID de compra = {compraId}] [fecha = {fecha}] ID producto = [{productoId}] Cantidad = [{cantidad}] ID Usuario[{usuarioId}]";
        }
    }
}
