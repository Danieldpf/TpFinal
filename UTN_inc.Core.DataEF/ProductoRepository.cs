using Microsoft.EntityFrameworkCore;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    //esto es un patron de diseño llamado Repositorio/Repository
    //patron de acceso a datos
    public class ProductoRepository
    {
        //Codigo Dani
        /*
        //El repositorio de una entidad de negocio se encarga de obtener, manipular, enviar, borrar, de ese tipo de entidad o todo lo relacionado a ese
        //tipo de entidad no es 1 a 1 en tablas


        private readonly Config _config;//aca con el readonly nadie lo puede cambiar / solamente en el constructor

        public ProductoRepository(Config config)//cuando se crea un repo hay que pasarle la congiguracion
        {//inyeccion
            _config = config;//esto toma el valor que le pasemos por configuracion 
        }


        //Probando COnsola
        public ProductoRepository()//Inyeccion por contructor (CREO)
        {
            _config = new Config();
        }

        //este metodo no esta conectado a la base de datos es solo para visualizar en la web
        public List<Producto> Agregar1000()
        {
            var producto = new List<Producto>();

            for (int i = 0; i < 1000; i++)
            {
                producto.Add(new Producto()
                {
                    ProductoId = i,
                    Nombre = $"producto {i}"

                });
            }
            return producto;
        }

        //el result es algo mas de diseño de software / es un tipo de objeto que yo recivo, envio, manipulo. para que lleve el dato original y el dato de error
        public ProductoResult GetAll()
        {
            var result = new ProductoResult();

            using (var db = new UTN_incContext(_config))
            {
                result.productos = db.productos.ToList();
            }

            return result;
        }


        public GenericResult DeleteAsync(int productoId)
        {
            var result = new GenericResult();

            using (var db = new UTN_incContext(_config))
            {

                var prod = from p in db.productos
                           where p.ProductoId == productoId
                           select p;

                var entityEntry = db.productos.Remove(prod.FirstOrDefault());//el profe dijo que iba a averiguar que es entityEntry que seria lo que devuelve el remove

                db.SaveChanges();//con esta linea se termina la transaccion / si no se hace esto no se guarda la modificacion

            }

            return result;
        }


        public Producto GetAsync(int productoId)
        {


            using (var db = new UTN_incContext(_config))
            {

                var prod = from p in db.productos
                           where p.ProductoId == productoId
                           select p;

                return prod.FirstOrDefault();
            }


        }



        public GenericResult UpdateAsync(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                db.Attach(producto);//buscar que es Attach  // El objeto tiene que tener un ID // sabe si tiene ID porque busca en la tabla o una columna ID o una con el mismo nombre de la EntidadID
                                    // EN caso de que no tenga ese nombre o por ejemplo que se llame producto_ID tendriamos que especificar en la propiedad cual es la key(Clave primaria)
                                    //haciendo Mapeo/inyectando un atributo sobre la propiedad [Key]

                //db.Entry(producto).Property(producto => producto.Name).IsModified = true;//Modifico un campo especifico
                db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//Modifico el objeto completo


                db.SaveChanges();

            }

            var result = new GenericResult();
            result.EsExitoso = true;
            return result;


        }
        */




        private readonly Config _config;

        public ProductoRepository(Config config)
        {
            _config = config;
        }



        public void ProductoCreate(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                var prod = (from p in db.productos
                            where p.Nombre == producto.Nombre
                            select p);
                if (prod.Any())
                {
                    GenericResult<List<Producto>>.Error("Nombre existente");
                }
                else
                {
                    db.productos.Add(producto);
                    db.SaveChanges();
                    GenericResult<Producto>.Ok(producto, "Borrado");
                }
            }
        }


        public GenericResult<List<Producto>> ProductoGetAll()
        {
            using (var db = new UTN_incContext(_config))
            {
                var productos = (from p in db.productos
                                 select p).ToList();

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

        /*
         public GenericResult<Producto> ProductoDelete(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                var prod = (from p in db.productos
                            where p.Nombre == producto.Nombre
                            select p);
                if (prod.Any())
                {
                    return GenericResult<Producto>.Error("No existe el elemento");
                }
                else
                {
                    
                    db.productos.Remove(producto);
                    db.SaveChanges();
                    return GenericResult<Producto>.Ok(producto, "Borrado");
                }
            }
        }
         */


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


        /*
        //public GenericResult<Producto> ProductoUpdate(int productoId)
        public GenericResult<Producto> ProductoUpdate(Producto producto)
        {
            using (var db = new UTN_incContext(_config))
            {
                /* db.Attach(producto);
                 buscar que es Attach  
                  El objeto tiene que tener un ID 
                  sabe si tiene ID porque busca en la tabla o una columna ID o una con el mismo nombre de la EntidadID      
                  EN caso de que no tenga ese nombre o por ejemplo que se llame producto_ID tendriamos que especificar 
                  en la propiedad cual es la key(Clave primaria)
                 haciendo Mapeo/inyectando un atributo sobre la propiedad [Key]
                 db.Entry(producto).Property(producto => producto.Name).IsModified = true;
                 Modifico un campo especifico
                 db.Entry(producto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;//Modifico el objeto completo
                 db.SaveChanges();

                var prod = (from p in db.productos
                            where p.ProductoId == producto.ProductoId
                            select p);

                prod

                if (prod.Any())
                {
                     GenericResult<List<Producto>>.Error();
                    return null;
                }
                else
                {

                    //db.Attach(productoId);
                    //db.Entry(productoId).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    //db.SaveChanges();
                    // Actualizar los campos específicos del producto
                    prod = producto.Nombre;
                    prod = producto.Descripcion;
                    prod. = producto.Precio;
                    prod.CategoriaId = producto.CategoriaId;


                    // Marcar el estado del producto como modificado
                    db.Entry(prod).State = EntityState.Modified;
                    db.SaveChanges();


                    return prod.FirstOrDefault();
                }
                */

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



    }

}

       


