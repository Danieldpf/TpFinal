
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.Business
{
    public class ProductoBusiness
    {
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
                return result;
            }
            else
            {
                // Si el resultado no es exitoso, retornamos un resultado con error.
                return GenericResult<List<Producto>>.Error("Hubo un error");
            }
        }

        public List<Producto> GetAll2()
        {

            var result = _productoRepository.ProductoGetAll2().Data;
            
            if (result != null)
            {
                return result;
            }
            else
            {
                return result;
            }
        }

        public GenericResult<Producto> DeleteAsync(int productoId)
        {
            //esto es lo que tiene el acceso a datos
            return _productoRepository.ProductoDelete(productoId);
        }


        public Producto GetProducto(int productoId)
        {

            var result = _productoRepository.ProductoGet(productoId);

            return result.Data;

        }

        public void CrearProductoBusiness(Producto producto)
        {
            _productoRepository.CrearProductoRepo(producto);
        }

       
        public GenericResult<Producto> UpdateBusiness(Producto productoID)//esto esta raro
        {
            var result = _productoRepository.ProductoUpdate(productoID);
            return result;
        }

        public List<Producto> ProductosEnUnaCategoriaBusiness(int categoriaId)
        {
            var result = _productoRepository.ProductosEnUnaCategoria(categoriaId);
            return result.Data;
        }

        

    }
}

