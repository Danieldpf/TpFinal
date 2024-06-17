using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN_inc.Core.Entities
{
    public class GenericResult
    {
        public string Mensaje { get; set; }

        public bool EsExitoso { get; set; }

        public bool TieneError { get; set; }
    }



    //********************************************************
    //          Agregado de Franco


    // Creamos un tipo generico de resultados, asi no tenemos que estar generando resultados para cada caso en especifico.
    // Lo realizamos con objetos de tipo generic.
    public class GenericResult<T>
    {

        //Constructor de la clase
        public GenericResult(T value)
        {
            Value = value;
        }

        //Constructor que se le asigna la propiedad OK para utilizar luego como falsa
        public GenericResult(bool OK = false) { this.OK = OK; }
        // Almacena el valor de tipo generico
        public T Value { get; }
        // Tipo generico de exitoso
        public bool OK { get; } = true;
        // Tipo generico de error
        public static GenericResult<T> Error() { return new GenericResult<T>(false); }


        //********************************************************
    }
}
