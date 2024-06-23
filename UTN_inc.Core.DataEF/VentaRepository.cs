using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;

namespace UTN_inc.Core.DataEF
{
    public class VentaRepository
    {
        private readonly Config _config;

        public VentaRepository(Config config)
        {
            _config = config;
        }
    }
}
