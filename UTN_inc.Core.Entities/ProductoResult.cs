using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{
    //se puede considerar DTO   // porque se sale de mi contexto Ejemplo si estoy en una api mi oj se sale porque lo evnio en json xml o lo que sea
    // si es para mi no es DTO
    public class ProductoResult
    {
        public List<Producto> productos { get; set; }

        public string mensaje { get; set; }

        public bool esError { get; set; }

    }
}
