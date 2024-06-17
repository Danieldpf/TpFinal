// See https://aka.ms/new-console-template for more information
using UTN_inc.Core.Business;

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
/*
var productoBusiness = new ProductoBusiness();

var productoResult = productoBusiness.GetAll();

//Muestra la lista
foreach (var item in productoResult.productos)
{
    Console.WriteLine(item.ToString());
}


var result = productoBusiness.DeleteAsync(1);

//Muestra la lista con el elemento eliminado
foreach (var item in productoResult.productos)
{
    Console.WriteLine(item.ToString());
}
*/



Console.WriteLine("FIN");