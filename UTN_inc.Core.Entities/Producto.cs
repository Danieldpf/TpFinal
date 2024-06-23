using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTN_inc.Core.Entities
{

    /******************************
                NOTAS
    Esto lo anoto porque el profesor tuvo un problema con los nombres en la clase 14/05/2024

    Por default entity framework pluraliza los nombres de los objetos

    aveces en la base de datos las entidades estan en plural, nosotros pusimos en singular
    Entonces tenemos que decirle a entityFramework que no busque la tabla en plural

    donde utilza [Table("Producto")] le dice que el nombre lo busque en Singular
    *******************************
     
    //sirve para matear el objeto relacion / indicarle que nombre tiene / explicitamente le digo el nombre de la tabla   / Clase del 14/05
    */
    [Table("Producto")]
    public class Producto
    {

        /*//en caso de que me de error por los nombres de las propiedades es porque no coincide con los de la BD lo que se puede hacer es
        //poner de misma manera que se puso la tabla arriba 

        //[Column("ProductoId")] seria asi para la columna / con esto hacemos el mapeo  /  a esto tambien se lo conoce como atributo de metodo o de clase / inyecta codigo
        */
        [Key]
        public int ProductoId { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public bool Habilitado { get; set; }

        

        public override string ToString()
        {
             return $"[ID = {ProductoId}] [Nombre = {Nombre}] [Estado = {Habilitado}] [Categoria = {Categoria?.NombreCategoria}] [ID de Categoria = {CategoriaId}]";
            //return $"{ProductoId} {Nombre} {Habilitado} {CategoriaId} {(Categoria != null ? Categoria.NombreCategoria : "No Categoria")}";
        }

    }
}

