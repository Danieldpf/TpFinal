// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

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

Console.WriteLine("soasdadasd");

var comprabusiness = new CompraBusiness();

comprabusiness.CrearCompraBusiness();

//Menu();

/*
//var productoBusiness = new ProductoBusiness();

//Console.WriteLine("GetAll Lista!");
//ListaProductos(productoBusiness);

//Console.WriteLine("Getall2 Lista!");
//ListVoid(productoBusiness);



//Console.WriteLine("Obtenido!");
//var jedi3 = productoBusiness.GetProducto(1006);//obtener//FUNCIONA
//Console.WriteLine("Obtenido! " + jedi3.ToString());

//Console.WriteLine("Modificado!");//FUNCIONA
//jedi3.Nombre = jedi3.Nombre + "??";//modificar
//var result = productoBusiness.UpdateBusiness(jedi3);//cargar

//Console.WriteLine("Eliminado!");
////var resultDelete = productoBusiness.DeleteAsync(1005);//FUNCIONA


//Console.WriteLine("Crear!\n\n\n");

//Console.WriteLine("LISTA CATEGORIA!");
//var categoriaBusiness = new CategoriaBusiness();
//GetCategoria(categoriaBusiness);

//Console.WriteLine("\n\n\n");
//GetAllCategoria(categoriaBusiness);

//Console.WriteLine("\n\n\n");
//ListVoid(productoBusiness, categoriaBusiness);
//Console.WriteLine("Lista nueva! / id 1002 tiene un ARG nuevo / id 1004 eliminado");

//ListaProductos(productoBusiness);

//List(productoBusiness);
*/

Console.WriteLine("FIN");

static void ListaProductos(ProductoBusiness productoBusiness)
{
    CategoriaBusiness cat = new CategoriaBusiness();

    var list = productoBusiness.GetAll().Data;
    var message = productoBusiness.GetAll().Message;

    

    foreach (var item in list)
    {
        
        Console.WriteLine(item.ToString());
        //Console.WriteLine("\n\n");
    }
    Console.WriteLine("Traer la lista fue "+message);
}

static void ListVoid(ProductoBusiness productoBusiness, CategoriaBusiness categoriaBusiness)
{
    var ListProductos = productoBusiness.GetAll2();
    var listCategoria = categoriaBusiness.GetAll().Data;

    foreach (var prod in ListProductos)
    {
        Console.Write(prod.ToString() + " ");

        foreach (var categ in listCategoria)
        {
            if (prod.CategoriaId == categ.CategoriaId)
            {
                Console.WriteLine(categ.NombreCategoria);
            }
        }
        
    }

    
}


static void GetCategoria(CategoriaBusiness categoriaBusiness)
{
    var cat = categoriaBusiness.GetCategoriaBus(3);

        Console.WriteLine(cat.NombreCategoria);
    
}

static void GetAllCategoria(CategoriaBusiness categoriaBusiness)
{
    var list = categoriaBusiness.GetAll().Data;

    foreach (var item in list)
    {
        Console.WriteLine(item.ToString());
    }

}



static void Menu()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Menú:");
        Console.WriteLine("1. Imprimir Todos los Productos");
        Console.WriteLine("2. Buscar Producto");
        Console.WriteLine("3. Agregar Producto");
        Console.WriteLine("4. Modificar Producto");
        Console.WriteLine("5. Eliminar Producto");
        Console.WriteLine("6. Lista de Categorias");
        Console.WriteLine("7. Productos en una categoria");
        Console.WriteLine("8. Salir");
        Console.Write("Seleccione una opción: ");

        int opcion = int.Parse(Console.ReadLine());

        var productoBusiness = new ProductoBusiness();
        var categoriaBusiness = new CategoriaBusiness();

        switch (opcion)
        {

            case 1:
                Console.WriteLine("Lista de productos");
                ListaProductos(productoBusiness);
                break;
            case 2:
                Console.WriteLine("Busqueda");//Se rompe el programa si se busca una id que no existe
                Console.WriteLine("Ingrese el ID del producto");
                int buscarId = int.Parse(Console.ReadLine());
                var productoObetenido = productoBusiness.GetProducto(buscarId);
                Console.WriteLine("\n"+productoObetenido.ToString());
                break;
            case 3:
                Console.WriteLine("Agregar");//FUNCIONA / FALTA VER EN QUE CASOS SE ROMPE POR EJEMPLO INGRESANDO NOMBRE DUPLICADO Y/O CATEGORIA INEXISTENTE
                Console.WriteLine("Ingrese los siguientes datos");
                Console.WriteLine("Nombre del Producto");
                string nombre = Console.ReadLine();
                Console.WriteLine("ID de la Categoria");
                int Idcategoria = int.Parse(Console.ReadLine());
                Console.WriteLine("Para Habilitado [Y] / Para Deshabilitado [N]");
                string habilitado = Console.ReadLine();
                bool habilitadoReal = false;

                if (habilitado == "y" || habilitado == "Y")
                {
                    habilitadoReal = true;
                }
                else if(habilitado == "n" || habilitado == "N")
                {
                    habilitadoReal = false;
                }
                //var entidadCategoria = categoriaBusiness.GetCategoriaBus(Idcategoria);//ESTO NO LO ESTOY OCUPANDO PERO LA IDEA ERA TRAER LA ENTIDAD CATEGORIA Y ASIGNARLE AL OBJETO CATEGORIA DENTRO DE PRODUCTO PERO NO SE PUEDE POR RESTRICCIONES DE LA BASE DE DATOS,TAMPOCO ES NECESARIO AL PARECER POR LAS RELACIONES DE LA CLAVES
                var nuevoProducto = new Producto { Nombre = nombre, CategoriaId = Idcategoria, Habilitado = habilitadoReal};
                productoBusiness.CrearProductoBusiness(nuevoProducto);
                break;
            case 4:
                Console.WriteLine("Modificar");// Mismo Problema que la busqueda pero a parte hay que buscar primero antes de solicitar
                //el ingreso de datos / Controlar el ingreso de una categoria que no existe, eso tambien rompe el programa
                Console.WriteLine("Ingrese el ID del producto");
                buscarId = int.Parse(Console.ReadLine());
                productoObetenido = productoBusiness.GetProducto(buscarId);

                Console.WriteLine("Ingrese los siguientes datos");
                Console.WriteLine("Nombre");
                nombre = Console.ReadLine();
                Console.WriteLine("Categoria");
                int categoria = int.Parse(Console.ReadLine());
                Console.WriteLine("(Y) Habilitado / (N) para deshabilitado");
                habilitado = Console.ReadLine();

                productoObetenido.Nombre = nombre;
                productoObetenido.CategoriaId = categoria;
                //productoObetenido.Categoria = Hacer metodo que busque la categoria con el id de categoria que se ingresa y asignarle
                //en este campo, de lo contrario se pierde la referencia al nombre, el resto funciona

                if (habilitado == "y" || habilitado == "Y")
                {
                    productoObetenido.Habilitado = true;
                }
                else if (habilitado == "n" || habilitado == "N")
                {
                    productoObetenido.Habilitado = false;
                }
                
                var result = productoBusiness.UpdateBusiness(productoObetenido);
                if (result.Success)
                {
                    Console.WriteLine("Producto modificado " + result.Data.ToString());
                }
                else
                {
                    Console.WriteLine(result.Message+" "+result.Errores);
                }
                break;
            case 5:
                Console.WriteLine("Eliminar");// FUNCIONA CORRECTAMENTE
                Console.WriteLine("Ingrese el ID del producto");
                buscarId = int.Parse(Console.ReadLine());
                result = productoBusiness.DeleteAsync(buscarId);

                if (result.Success)
                {
                    Console.WriteLine("Producto Eliminado " + result.ToString());
                }
                else
                {
                    Console.WriteLine(result.Message + " " + result.Errores);
                }
                break;
            case 6:
                Console.WriteLine("Lista de Categorias");
                GetAllCategoria(categoriaBusiness);
                break;
            case 7:
                Console.WriteLine("Ingrese el id de la categoria");
                buscarId = int.Parse(Console.ReadLine());
                var productosEnUnaCategoria = productoBusiness.ProductosEnUnaCategoriaBusiness(buscarId);

                foreach (var item in productosEnUnaCategoria)
                {
                    Console.WriteLine(item.Nombre);
                }
                break;
            case 8:
                Console.WriteLine("Saliendo del programa...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }

        Console.WriteLine("\nPresione Enter para continuar...");
        Console.ReadLine();
    }
}





