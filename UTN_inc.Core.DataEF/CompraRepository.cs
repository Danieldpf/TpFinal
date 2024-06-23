using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    public class CompraRepository
    {
        private readonly Config _config;

        public CompraRepository(Config config)
        {
            _config = config;
        }

        public void CrearCompraRepo(/*Compra nuevaCompra*/)
        {
            var productoRepo = new ProductoRepository(_config);//TRAIGO PRODUCTOS

            Console.Write("Ingrese Id del producto que quiere comprar");
            int productoId = int.Parse(Console.ReadLine());//OBTENGO UN ID
            var productos = productoRepo.ProductoGet(productoId);//BUSCO ESE PRODUCTO

           
            
            Console.Write("Ingrese la fecha (formato dd/MM/yyyy): ");
            DateTime fechaCompra;
            string fechaString = Console.ReadLine();
            fechaCompra = DateTime.ParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime fechaLimite = DateTime.Now.AddDays(-7);
            
            if (fechaCompra < fechaLimite || fechaCompra > DateTime.Now)
            {
                Console.WriteLine("Fecha Fuera de rango");
            }
            /*
            try
            {
                fechaCompra = DateTime.ParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error al ingresar la fecha: " + e.Message);
                fechaCompra = DateTime.MinValue; // Valor por defecto en caso de error
            }

            Console.WriteLine("Fecha ingresada: " + fechaCompra);
            */

            Console.Write("Ingrese la cantidad que quiere comprar");
            int cantidad = int.Parse(Console.ReadLine());
            if (cantidad <= 0)
            {
                Console.WriteLine("La compra no puede ser menor a 1");
            }
            else
            {
                //ver que poner aca
            }


            var nuevaCompra = new Compra
            {
                fecha = fechaCompra,
                productoId = productos.Data.ProductoId,
                cantidad = cantidad,
                usuarioId = UsuarioGlobal.GetUsuario()

            };
            

            using (var db = new UTN_incContext(_config))
            {
                db.compras.Add(nuevaCompra);
                db.SaveChanges();
                             
            }
        }

        public void ObtenerCompraRepo()
        {

        }
        /*
        
        ◦ CompraId
        ◦ Fecha
        ◦ ProductoId
        ◦ Cantidad
        ◦ UsuarioId
        */
    }
}
