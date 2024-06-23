using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{

    // Creamos un tipo generico de resultados, asi no tenemos que estar generando resultados para cada caso en especifico.
    // Lo realizamos con objetos de tipo generic.
    public class GenericResult<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public List<string> Errores { get; set; }

        public List<Producto> productos { get; set; }


        //Constructor de la clase
        public GenericResult()
        {
            Errores = new List<string>();
            productos = new List<Producto>();
        }

        


        public static GenericResult<T> Ok(T data, string message = "")
        {
            return new GenericResult<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }


        public static GenericResult<T> Error(string message, List<string> errores = null)
        {
            return new GenericResult<T>
            {
                Success = false,
                Errores = errores,
                Message = message
            };
        }

       
    }

}
