// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;
using static System.Collections.Immutable.ImmutableArray<T>;

Console.WriteLine("Hello, World!");


//la capa business esta entre la app y el acceso a datos
//Business tiene toda la logica del negocio



//Dependencias Entities -> TpFinal que en este caso es el proyecto de consola
//Business -> TpFinal
//Entities -> Business
//Data -> Business
//Entities -> Data
// EN Data se agrego un Nuget "System.Data.SqlClient" / esta parte del trabajo no esta entity framework
//Entities -> DataEF
//DataEF -> Business
//La Capa de DataEF se agrego la dependencia (nuget) MicrosoftEntityFrameworkSqlServer
//En la capa de Entities se agrego la dependencia (nuget) Microsoft.EntityFrameworkCore.Relational
//Business -> WebUTN_inc
//entities -> WebUTN_inc
//Configuracion -> DataEF


//la idea es que la consola o app llame a la capa de business / business tiene que obtener los datos de un repoitorio 


var productoBusiness = new ProductoBusiness();

Console.WriteLine("Lista!");
List(productoBusiness);

//var result = jediBusiness.DeleteAsync(9);//Borrado

Console.WriteLine("Obtenido!");
var jedi3 = productoBusiness.GetProducto(1003);//obtener
Console.WriteLine("Obtenido! "+ jedi3.ToString());

Console.WriteLine("Modificado!");
jedi3.Nombre = jedi3.Nombre + "ARG";//modificar
var result = productoBusiness.Update(jedi3);//cargar

Console.WriteLine("Eliminado!");
Console.WriteLine(productoBusiness.ToString());
//var result = productoBusiness.DeleteAsync(jedi3);//NO anda
Console.WriteLine(productoBusiness.ToString());
Console.WriteLine("Lista nueva! / id 1002 tiene un ARG nuevo / id 1004 eliminado");

List(productoBusiness);

Console.WriteLine("END!");

static GenericResult<List<Producto>> List(ProductoBusiness productoBusiness)
{
    var jedisResult = productoBusiness.GetAll();

    //if (jedisResult.HasError)
    //{
    //    Console.WriteLine($"ERROR: {jedisResult.Message}");
    //}
    //else
    //{
    foreach (var item in jedisResult.productos)
    {
        Console.WriteLine(item.ToString());
    }
    return jedisResult;
}



//var productoBusiness = new ProductoBusiness();

//var productoResult = productoBusiness.GetAll();

////Muestra la lista
//foreach (var item in productoResult.productos)
//{
//    Console.WriteLine(item.ToString());
//}


//var result = productoBusiness.DeleteAsync(1);

////Muestra la lista con el elemento eliminado
//foreach (var item in productoResult.productos)
//{
//    Console.WriteLine(item.ToString());
//}




Console.WriteLine("FIN");