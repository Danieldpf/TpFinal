using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;

namespace UTN_inc.Core.Business
{
    public class CompraBusiness
    {

        private readonly CompraRepository _compraRepository;

        private readonly Config _config;

        //*************Agregue el constructor de abajo y comente este
        public CompraBusiness()
        {
            // temporal hasta hacer inyeccion de dependencias
            _compraRepository = new CompraRepository(_config);
        }
        //*********************************************************

        public CompraBusiness(CompraRepository compraRepository)
        {

            _compraRepository = compraRepository;
        }

        
        public void CrearCompraBusiness()
        {
            _compraRepository.CrearCompraRepo();
        }
    }
}
