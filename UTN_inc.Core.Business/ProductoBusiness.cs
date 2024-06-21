
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.Business
{
    public class ProductoBusiness
    {
      


            //clase privada que esta en la capa de datos

            // se encarga de trar de la vuente de datos o llevar los objetos como ProductoBusiness(esto hay que ver bien si es asi)
        /*    private readonly ProductoRepository _productoRepository;



        //Prueba Consola
        public ProductoBusiness()
        {
            // temporal hasta hacer inyeccion de dependencias
            _productoRepository = new ProductoRepository();
        }

        public ProductoBusiness(ProductoRepository productoRepository)
        {
            // temporal hasta hacer inyeccion de dependencias
            _productoRepository = productoRepository;
        }

        //devuelve el listado de producto
        public ProductoResult GetAll()
        {
            //esto es lo que tiene el acceso a datos
            return _productoRepository.GetAll();
        }


        public GenericResult DeleteAsync(int productoId)
        {
            //esto es lo que tiene el acceso a datos
            return _productoRepository.DeleteAsync(productoId);
        }

        public Producto GetAsync(int productoId)
        {
            //esto es lo que tiene el acceso a datos
            return _productoRepository.GetAsync(productoId);
        }


        public GenericResult UpdateAsync(Producto producto)
        {
            //esto es lo que tiene el acceso a datos
            return _productoRepository.UpdateAsync(producto);
        }
        */


        //********************************************************************
        //Agregado Franco
        //clase privada que esta en la capa de datos

        // se encarga de trar de la vuente de datos o llevar los objetos como ProductoBusiness(esto hay que ver bien si es asi)
        private readonly ProductoRepository _productoRepository;

        private readonly Config _config;

        //*************Agregue el constructor de abajo y comente este
        public ProductoBusiness()
        {
            // temporal hasta hacer inyeccion de dependencias
            _productoRepository = new ProductoRepository(_config);
        }
        //*********************************************************

        public ProductoBusiness(ProductoRepository productoRepository)
        {

            _productoRepository = productoRepository;
        }


        //devuelve el listado de producto
        public GenericResult<List<Producto>> GetAll()
        {
            var result = _productoRepository.ProductoGetAll();

            if (result != null)
            {
                // Si el resultado es exitoso, retornamos el resultado tal cual.
                //foreach (var item in result.productos)
                //{
                //    Console.WriteLine(item.ToString());
                //}
                return result;
            }
            else
            {
                // Si el resultado no es exitoso, retornamos un resultado con error.
                return GenericResult<List<Producto>>.Error("Hubo un error");
            }

            return result;
        }
        public void DeleteAsync(Producto producto)
        {
            //esto es lo que tiene el acceso a datos
            _productoRepository.ProductoDelete(producto);
        }

        public Producto GetProducto(int productoId)
        {

            var result = _productoRepository.ProductoGet(productoId);

            return result.Data;

        }

        /*
        public GenericResult<Producto> UpdateAsync(int productoId)
        {
            //esto es lo que tiene el acceso a datos
            /*var result = _productoRepository.ProductoUpdate(producto.ProductoId);
            return result;

            var result = _productoRepository.ProductoUpdate(productoId);

            
            

        }
        */

        public GenericResult<Producto> Update(Producto producto)
        {
            var result = _productoRepository.ProductoUpdate(producto);
            return result;
        }

        //********************************************************************


    }
}


/*
 el rerpositorio es un patron

 */