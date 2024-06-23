using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.Business
{
    public class CategoriaBusiness
    {

        private readonly CategoriaRepository _categoriaRepository;



        private readonly Config _config;

        public CategoriaBusiness()
        {
            // temporal hasta hacer inyeccion de dependencias
            _categoriaRepository = new CategoriaRepository(_config);
        }


        public Categoria GetCategoriaBus(int categoriaId)
        {

            var result = _categoriaRepository.GetCategoriaRepo(categoriaId);

            return result.Data;

        }

        public GenericResult<List<Categoria>> GetAll()
        {
            var result = _categoriaRepository.GetAllCategoriaRepo();

            if (result != null)
            {
                
                return result;
            }
            else
            {
                // Si el resultado no es exitoso, retornamos un resultado con error.
                return GenericResult<List<Categoria>>.Error("Hubo un error");
            }
        }


        /*public GenericResult<List<Categoria>> ListaProductosDeUnaCategoriaBusiness(int categoriaId)
        {
            var result = _categoriaRepository.ListaDeProductosEnCategoria(categoriaId);
            return result;
            
        }*/

        



    }
}
