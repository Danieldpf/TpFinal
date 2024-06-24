using Microsoft.EntityFrameworkCore;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    //esto es un patron de diseño llamado Repositorio/Repository
    //patron de acceso a datos
    public class ProductoRepository
    {
        

        private readonly Config _config;

        public ProductoRepository(Config config)
        {
            _config = config;
        }

        

        public void CrearProductoRepo(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                var prod = (from p in db.productos
                            where p.Nombre == producto.Nombre
                            select p).Include(p => p.Categoria).ToList(); ;
                if (prod.Any())
                {
                    GenericResult<List<Producto>>.Error("Nombre de producto existente no es posible agregarlo");
                    Console.WriteLine("Nombre de producto existente no es posible agregarlo");
                }
                else
                {
                    db.productos.Add(producto);
                    db.SaveChanges();
                    GenericResult<Producto>.Ok(producto, "Exito al Crear");
                    Console.WriteLine("Exito al Crear");
                }

            }
        }

        //Obtener todos los productos 1
        public GenericResult<List<Producto>> ProductoGetAll()
        {
            using (var db = new UTN_incContext(_config))
            {
                var productos = (from p in db.productos
                                 select p).Include(p => p.Categoria).ToList();

                //var producto = db.Productos.Include(p => p.Categoria).First();

                if (productos.Any())
                {
                    // Si hay productos disponibles, retornamos un resultado exitoso con la lista de productos.
                    return GenericResult<List<Producto>>.Ok(productos,"Exito");
                }
                else
                {
                    // Si no hay productos disponibles, retornamos un resultado no exitoso.
                    return GenericResult<List<Producto>>.Error("Error Vacio");
                }
            }
        }
        /*
        //Obtener todos los productos 2
        public GenericResult<List<Producto>> ProductoGetAll2()
        {
            using (var db = new UTN_incContext(_config))
            {
                var productos = (from p in db.productos
                                 select p).ToList();

                if (productos.Any())
                {
                    // Si hay productos disponibles, retornamos un resultado exitoso con la lista de productos.
                    return GenericResult<List<Producto>>.Ok(productos, "Exito");
                    
                }
                else
                {
                    // Si no hay productos disponibles, retornamos un resultado no exitoso.
                    return GenericResult<List<Producto>>.Error("Error Vacio");
                }
            }
        }
        */

        //Borrar Producto
        public GenericResult<Producto> ProductoDelete(int productoId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var prod = (from p in db.productos
                            where p.ProductoId == productoId
                            select p).FirstOrDefault();
                if (prod != null)
                {
                    db.productos.Remove(prod);
                    db.SaveChanges();
                    return GenericResult<Producto>.Ok(prod, "Borrado");
                }
                else
                {
                    return GenericResult<Producto>.Error("No existe el elemento");
                }
            }
        }

        //Obtener Producto
        public GenericResult<Producto> ProductoGet(int productoId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var prod = (from p in db.productos
                            where p.ProductoId == productoId
                            select p).FirstOrDefault();

                if (prod != null)
                {
                    // Si el producto se encuentra, retornamos un resultado exitoso.
                    return GenericResult<Producto>.Ok(prod,"Exito");
                }
                else
                {
                    // Si el producto no se encuentra, retornamos un resultado no exitoso.
                    return GenericResult<Producto>.Error("No existe");
                }
            }

        }

        //Actualizar Producto
        public GenericResult<Producto> ProductoUpdate(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                // Verificar si el producto existe
                var existingProduct = db.productos
                    .FirstOrDefault(p => p.ProductoId == producto.ProductoId);

                if (existingProduct == null)
                {
                    return GenericResult<Producto>.Error("No existe");
                }

                // Verificar si el nombre del producto está duplicado
                var duplicateProduct = db.productos
                    .FirstOrDefault(p => p.Nombre == producto.Nombre && p.ProductoId != producto.ProductoId);

                if (duplicateProduct != null)
                {
                    return GenericResult<Producto>.Error("Nombre duplicado");
                }

                // Actualizar los campos específicos del producto
                existingProduct.Nombre = producto.Nombre;
                existingProduct.CategoriaId = producto.CategoriaId;
                existingProduct.Habilitado = producto.Habilitado;

                // Marcar el estado del producto como modificado
                db.Entry(existingProduct).State = EntityState.Modified;
                db.SaveChanges();

                return GenericResult<Producto>.Ok(producto, "Exito");
            }
        }


        public GenericResult<List<Producto>> ProductosEnUnaCategoria(int categoriaId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var productos = (from p in db.productos
                                 where p.CategoriaId == categoriaId
                                 select p).ToList();

                if (productos.Any())
                {
                    // Si hay productos disponibles, retornamos un resultado exitoso con la lista de productos.
                    return GenericResult<List<Producto>>.Ok(productos, "Exito");

                }
                else
                {
                    // Si no hay productos disponibles, retornamos un resultado no exitoso.
                    return GenericResult<List<Producto>>.Error("Error Vacio");
                }
            }
        }

    }

}

       


