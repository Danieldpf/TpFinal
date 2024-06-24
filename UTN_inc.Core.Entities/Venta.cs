using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{
    [Table("Venta")]
    public class Venta
    {
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; }
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }
        [ForeignKey("Usuarios")]
        public int UsuarioId { get; set; }


        public override string ToString()
        {
            return $"ID de Compra: {VentaId}  Fecha: {Fecha}  ID Producto: {ProductoId}  Cantidad: {Cantidad}  ID Usuario: {UsuarioId}";
        }
    }
}
