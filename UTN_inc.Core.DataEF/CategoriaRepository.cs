using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    public class CategoriaRepository
    {


        private readonly Config _config;

        public CategoriaRepository(Config config)
        {
            _config = config;
        }


        public GenericResult<Categoria> GetCategoriaRepo(int categoriaId)
        {
            using (var db = new UTN_incContext(_config))
            {
                var cate = (from p in db.categorias
                            where p.CategoriaId == categoriaId
                            select p).FirstOrDefault();

                if (cate != null)
                {
                    // Si el producto se encuentra, retornamos un resultado exitoso.
                    return GenericResult<Categoria>.Ok(cate, "Exito");
                }
                else
                {
                    // Si el producto no se encuentra, retornamos un resultado no exitoso.
                    return GenericResult<Categoria>.Error("No existe");
                }
            }

        }


        public GenericResult<List<Categoria>> GetAllCategoriaRepo()
        {
            using (var db = new UTN_incContext(_config))
            {
                var cate = (from p in db.categorias
                                 select p).ToList();

                if (cate.Any())
                {
                    // Si hay productos disponibles, retornamos un resultado exitoso con la lista de productos.
                    return GenericResult<List<Categoria>>.Ok(cate, "Exito");
                }
                else
                {
                    // Si no hay productos disponibles, retornamos un resultado no exitoso.
                    return GenericResult<List<Categoria>>.Error("Error Vacio");
                }
            }
        }


        public GenericResult<List<Categoria>> CargaListaCategoriaRepo()
        {
            var categorias = new Categoria();
            using (var db = new UTN_incContext(_config))
            {
                var cate = (from p in db.categorias
                            select p).ToList();


                if (cate.Any())
                {
                    // Si hay productos disponibles, retornamos un resultado exitoso con la lista de productos.
                    return GenericResult<List<Categoria>>.Ok(cate, "Exito");
                }
                else
                {
                    // Si no hay productos disponibles, retornamos un resultado no exitoso.
                    return GenericResult<List<Categoria>>.Error("Error Vacio");
                }
            }
        }

       

    }
}
