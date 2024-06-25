// See https://aka.ms/new-console-template for more information
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;


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





Menu2();

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


static void GetAllCategoria(CategoriaBusiness categoriaBusiness)
{
    var list = categoriaBusiness.GetAll().Data;

    foreach (var item in list)
    {
        Console.WriteLine(item.ToString());
    }

}

static void Menu2()
{

    while (true)
    {
        try
        {

            var usuariobusiness = new UsuarioBusiness();

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("¡Bienvenido! Indique si quiere Ingresar o Registrarse: \n");
            Console.WriteLine("1. LOGIN");
            Console.WriteLine("2. Crear Usuario");
            Console.WriteLine("3. Ver Usuarios");
            Console.WriteLine("4. Eliminar Usuario");
            Console.WriteLine("5. Salir :c");
            Console.WriteLine("-----------------------------------------------------------------");
            int opcionIngreso = int.Parse(Console.ReadLine());

            var compraBusiness = new CompraBusiness();
            var ventaBusiness = new VentaBusiness();

            switch (opcionIngreso)
            {
                case 2:
                    Console.Clear();
                    Console.WriteLine("Creacion de usuario");
                    Console.WriteLine("\nIngrese Nombre del usuario: ");
                    string nombre = Console.ReadLine().ToLower();
                    Console.WriteLine("\nIngrese Contraseña del usuario: ");
                    string contraseña = Console.ReadLine();
                    string contraSalt = GeneradorHashSalt.GenerarSalt(contraseña);
                    int salt = GeneradorHashSalt.GetSalt();
                    var nuevoUsuario = new Usuarios
                    {
                        Nombre = nombre,
                        salt = salt,
                        hash = GeneradorHashSalt.GenerarHash(contraSalt)
                    };
                    usuariobusiness.CrearUsuarioBusiness(nuevoUsuario);

                    break;

                case 1:
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("LOGIN");
                        Console.WriteLine("\nIngresar Nombre de Usuario: ");
                        string usuario = Console.ReadLine();
                        Console.WriteLine("\nIngresar Contraseña: ");
                        contraseña = Console.ReadLine();

                        var usuarioLogg = usuariobusiness.ObtenerUnUsuariosBusiness(usuario);   //Traigo el usuario con ese nombre

                        
                        if (usuarioLogg != null)
                        {
                            contraseña = usuarioLogg.salt + contraseña;//Traigo el salt de ese usuario y lo concateno al la contraseña en el mismo orden que se genera
                            contraseña = GeneradorHashSalt.GenerarHash(contraseña);//Genero el Hash de nuevo

                            if (contraseña == usuarioLogg.hash)// Compruebo que el usuario no sea nulo y que el hash sea el mismo
                            {

                                Console.Clear();
                                UsuarioGlobal.SetUsuario(usuarioLogg.UsuarioId);
                                Console.WriteLine("Usuario Logueado \n" + usuarioLogg.ToString());
                                Console.WriteLine("Usuario Global: " + UsuarioGlobal.GetUsuario());

                                Menu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Usuario o contraseña Invalido");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Error al Ingresar los Datos de Usuario.");
                    }
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Ver Usuarios");
                    var listUsuarios = usuariobusiness.ObtenerUsuariosBusiness();

                    foreach (var usser in listUsuarios)
                    {
                        Console.WriteLine(usser.ToString());
                    }
                    break;
                case 4:
                    Console.WriteLine("Eliminar Usuario");
                    Console.WriteLine("Ingrese el id del Usuario");
                    var IdUsuario = int.Parse(Console.ReadLine());
                    compraBusiness.EliminarComprasDeUnUsuarioBusiness(IdUsuario);
                    ventaBusiness.EliminarVentasDeUnUsuarioBusiness(IdUsuario);
                    usuariobusiness.EliminarUsuarioBusiness(IdUsuario);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa... ¡Adios!\n\n");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción no válida. Intente Otra vez...");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.Clear();
            Console.WriteLine("Opción no válida. Intente Otra vez...");
        }
    }

}
static void Menu()
{
    while (true)
    {
        try
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Menú:");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("1. Imprimir Todos los Productos");
            Console.WriteLine("2. Buscar Producto");
            Console.WriteLine("3. Agregar Producto");
            Console.WriteLine("4. Modificar Producto");
            Console.WriteLine("5. Eliminar Producto");
            Console.WriteLine("6. Lista de Categorias");
            Console.WriteLine("7. Productos en una categoria");
            Console.WriteLine("8. Hacer Compra");
            Console.WriteLine("9. Obtener Compra");
            Console.WriteLine("10. Hacer Venta");
            Console.WriteLine("11. Obtener Una Venta");
            Console.WriteLine("12. Ventas por Usuario");
            Console.WriteLine("13. Compras por Usuario");
            Console.WriteLine("14. Eliminar 1 Compra");
            Console.WriteLine("15. Eliminar 1 Venta");
            Console.WriteLine("16. Salir");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.Write("Seleccione una opción: ");
            Console.WriteLine("\n-----------------------------------------------------------------");

            int opcion = int.Parse(Console.ReadLine());

            var productoBusiness = new ProductoBusiness();
            var categoriaBusiness = new CategoriaBusiness();
            var compraBusiness = new CompraBusiness();
            var ventaBusiness = new VentaBusiness();
            var usuariobusiness = new UsuarioBusiness();//esto estaba abajo de la creacion del nuevo usuario en la consola

            switch (opcion)
            {

                case 1:
                    Console.Clear();
                    Console.WriteLine("Lista de productos");
                    ListaProductos(productoBusiness);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Busqueda");//Se rompe el programa si se busca una id que no existe
                    Console.WriteLine("Ingrese el ID del producto");
                    int buscarId = int.Parse(Console.ReadLine());
                    var productoObetenido = productoBusiness.GetProducto(buscarId);
                    var categoriaDeProd = categoriaBusiness.GetCategoriaBus(productoObetenido.CategoriaId);
                    productoObetenido.Categoria = categoriaDeProd;
                    Console.Clear();
                    Console.WriteLine(productoObetenido.ToString());
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("3. Agregar Producto");
                    Console.WriteLine("Ingrese los Datos del Producto\n");
                    Console.WriteLine("Nombre del Producto: ");
                    string nombre = Console.ReadLine().ToLower();
                    Console.WriteLine("\nIngrese la ID de la Categoria que Corresponde: ");
                    GetAllCategoria(categoriaBusiness);
                    Console.WriteLine("\n");
                    int Idcategoria = int.Parse(Console.ReadLine());
                    Console.WriteLine("\nPara Habilitado [Y] / Para Deshabilitado [N]");
                    string habilitado = Console.ReadLine();
                    bool habilitadoReal = false;

                    if (habilitado == "y" || habilitado == "Y")
                    {
                        habilitadoReal = true;
                    }
                    else if (habilitado == "n" || habilitado == "N")
                    {
                        habilitadoReal = false;
                    }


                    var nuevoProducto = new Producto { Nombre = nombre, CategoriaId = Idcategoria, Habilitado = habilitadoReal };
                    productoBusiness.CrearProductoBusiness(nuevoProducto);
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Modificar");// Mismo Problema que la busqueda pero a parte hay que buscar primero antes de solicitar
                                                   //el ingreso de datos / Controlar el ingreso de una categoria que no existe, eso tambien rompe el programa
                    Console.WriteLine("\nIngrese el ID del producto: ");
                    buscarId = int.Parse(Console.ReadLine());
                    productoObetenido = productoBusiness.GetProducto(buscarId);

                    Console.WriteLine("\nIngrese los siguientes datos:");
                    Console.WriteLine("\nNombre: ");
                    nombre = Console.ReadLine();
                    Console.WriteLine("\nCategoria: ");
                    GetAllCategoria(categoriaBusiness);
                    Console.WriteLine("\n");
                    int categoria = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n(Y) Habilitado / (N) para deshabilitado");
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
                    Console.Clear();
                    var result = productoBusiness.UpdateBusiness(productoObetenido);
                    if (result.Success)
                    {
                        productoObetenido = productoBusiness.GetProducto(buscarId);
                        categoriaDeProd = categoriaBusiness.GetCategoriaBus(productoObetenido.CategoriaId);
                        productoObetenido.Categoria = categoriaDeProd;
                        Console.WriteLine(productoObetenido.ToString());
                    }
                    else
                    {
                        Console.WriteLine(result.Message + " " + result.Errores);
                    }
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Eliminar");
                    Console.WriteLine("\nIngrese el ID del producto: ");
                    buscarId = int.Parse(Console.ReadLine());
                    result = productoBusiness.DeleteAsync(buscarId);

                    if (result.Success)
                    {
                        Console.WriteLine("\nProducto Eliminado " + result.Data);
                    }
                    else
                    {
                        Console.WriteLine(result.Message + " " + result.Errores);
                    }
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Lista de Categorias");
                    GetAllCategoria(categoriaBusiness);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("\nIngrese el id de la categoria: ");
                    buscarId = int.Parse(Console.ReadLine());
                    var productosEnUnaCategoria = productoBusiness.ProductosEnUnaCategoriaBusiness(buscarId);
                    if (productosEnUnaCategoria != null)
                    {
                        Console.Clear();
                        Console.WriteLine("Los Productos Disponibles en esta Categoria son: ");
                        foreach (var item in productosEnUnaCategoria)
                        {
                            Console.WriteLine("\n" + item.Nombre);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Esa categoria no existe");
                    }
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Hacer Compra");
                    Console.Write("\nIngrese Id del producto que quiere comprar: ");
                    int productoId = int.Parse(Console.ReadLine());

                    Console.Write("\nIngrese la fecha (formato dd/MM/yyyy): ");
                    string fechaString = Console.ReadLine();

                    Console.Write("\nIngrese la cantidad que quiere comprar: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    string errorMessage;
                    string resultado = compraBusiness.CrearCompra(productoId, fechaString, cantidad, out errorMessage);

                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        Console.WriteLine(errorMessage);
                    }
                    else
                    {
                        Console.WriteLine(resultado);
                    }

                    break;
                case 9:
                    Console.Clear();
                    Console.Write("Ingrese Id de la compra: ");
                    int compraId = int.Parse(Console.ReadLine());
                    var compra = compraBusiness.ObtenerCompraBusiness(compraId);
                    if (compra != null)
                    {
                        Console.WriteLine($"\nCompra encontrada: {compra.fecha}, Producto ID: {compra.productoId}, Cantidad: {compra.cantidad}");
                    }
                    else
                    {
                        Console.WriteLine("\nCompra no encontrada.");
                    }
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("Hacer Venta");
                    Console.Write("\nIngrese Id del producto que quiere Vender: ");
                    productoId = int.Parse(Console.ReadLine());


                    Console.Write("\nIngrese la cantidad que quiere Vender: ");
                    cantidad = int.Parse(Console.ReadLine());

                    
                    var idCompra = compraBusiness.BuscarCompraPorProducto(productoId);
                    
                    if (idCompra != null)
                    {
                        var compraDe1Procudto = compraBusiness.ObtenerCompraBusiness(idCompra.compraId);
                       
                        if (compraDe1Procudto.cantidad > cantidad && productoBusiness.GetProducto(compraDe1Procudto.productoId).Habilitado == true)
                        {
                            resultado = ventaBusiness.CrearVenta(productoId, cantidad, out errorMessage);

                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                Console.WriteLine(errorMessage);
                            }
                            else
                            {
                                Console.WriteLine(resultado);
                            }
                        }
                        else if(productoBusiness.GetProducto(compraDe1Procudto.productoId).Habilitado == false)
                        {
                            Console.WriteLine("Producto deshabilitado");
                        }
                        else
                        {
                            Console.WriteLine("Stock de insuficiente");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Venta inexistente");
                    }
                   

                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("Obtener Venta");
                    Console.Write("\nIngrese Id de la Venta: ");
                    int VentaId = int.Parse(Console.ReadLine());
                    var venta = ventaBusiness.ObtenerVentaBusiness(VentaId);
                    if (venta != null)
                    {
                        Console.WriteLine($"Venta encontrada: {venta.Fecha}, Producto ID: {venta.ProductoId}, Cantidad: {venta.Cantidad}");
                    }
                    else
                    {
                        Console.WriteLine("Venta no encontrada.");
                    }
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("Ventas por Usuario");
                    Console.Write("\nIngrese Id del usuario: ");
                    int IdUsuario = int.Parse(Console.ReadLine());
                    var listVentas = ventaBusiness.VentasDeUnUsuarioBusiness(IdUsuario);//traigo la lista de ventas de 1 usuario


                    foreach (var venta2 in listVentas)
                    {//Imprimo los nombres de los productos que vendio y la cantidad
                        Console.WriteLine("\nVenta de " + productoBusiness.GetProducto(venta2.ProductoId).Nombre + " Cantidad " + venta2.Cantidad);
                    }

                    break;
                case 13:
                    Console.Clear();
                    Console.WriteLine("Compras por Usuario");
                    Console.Write("\nIngrese Id del usuario: ");
                    IdUsuario = int.Parse(Console.ReadLine());
                    var listCompras1uss = compraBusiness.ComprasDeUnUsuarioBusiness(IdUsuario);//traigo la lista de ventas de 1 usuario


                    foreach (var compra2 in listCompras1uss)
                    {//Imprimo los nombres de los productos que compro y la cantidad
                        Console.WriteLine("\nCompra de " + productoBusiness.GetProducto(compra2.productoId).Nombre + " Cantidad " + compra2.cantidad);
                    }

                    break;
                case 14:
                    Console.Clear();
                    Console.WriteLine("Eliminar una Compra");
                    Console.WriteLine("Ingrese id de la Compra");
                    compraId = int.Parse(Console.ReadLine());
                    compraBusiness.EliminarCompraBusiness(compraId);
                    break;
                case 15:
                    Console.Clear();
                    Console.WriteLine("Eliminar una Venta");
                    Console.WriteLine("Ingrese id de la Venta");
                    VentaId = int.Parse(Console.ReadLine());
                    ventaBusiness.EliminarVentaBusiness(VentaId);
                    break;
                case 16:
                    Console.Clear();
                    Console.WriteLine("Saliendo del programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("Error al Ingresar Algún Dato. Intente Otra Vez...");
        }
    }

    Console.WriteLine("\nPresione Enter para continuar...");
    Console.ReadLine();

}




/*
static void MenuTEST()
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
        Console.WriteLine("8. Crear Compra");
        Console.WriteLine("9. Obtener una Compra");
        Console.WriteLine("10. Crear Usuario");
        Console.WriteLine("11. Ver Usuarios");
        Console.WriteLine("12. LOGIN");
        Console.WriteLine("13. Ventas de 1 Usuario");
        Console.WriteLine("14. Compras de 1 Usuario");
        Console.WriteLine("15. Obtener Una Venta");
        Console.WriteLine("16. Crear Venta");
        Console.WriteLine("17. Eliminar Usuario");
        Console.WriteLine("18. Salir");
        Console.Write("Seleccione una opción: ");

        int opcion = int.Parse(Console.ReadLine());

        var productoBusiness = new ProductoBusiness();
        var categoriaBusiness = new CategoriaBusiness();
        var compraBusiness = new CompraBusiness();
        var ventaBusiness = new VentaBusiness();
        var usuariobusiness = new UsuarioBusiness();//esto estaba abajo de la creacion del nuevo usuario en la consola

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
                if (productoObetenido != null)
                {
                    var categoriaDeProd = categoriaBusiness.GetCategoriaBus(productoObetenido.CategoriaId);
                    productoObetenido.Categoria = categoriaDeProd;
                    Console.WriteLine("\n" + productoObetenido.ToString());
                }
                else 
                {
                    Console.WriteLine(productoObetenido);//TRAER EL ERROR DEL GENERIC
                }
                
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
                Console.WriteLine("Eliminar");
                Console.WriteLine("Ingrese el ID del producto");
                buscarId = int.Parse(Console.ReadLine());
                result = productoBusiness.DeleteAsync(buscarId);

                if (result.Success)
                {
                    Console.WriteLine("Producto Eliminado " + result.Data);
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
                Console.WriteLine("8. Crear Compra");
                Console.Write("Ingrese Id del producto que quiere comprar: ");
                int productoId = int.Parse(Console.ReadLine());

                Console.Write("Ingrese la fecha (formato dd/MM/yyyy): ");
                string fechaString = Console.ReadLine();

                Console.Write("Ingrese la cantidad que quiere comprar: ");
                int cantidad = int.Parse(Console.ReadLine());

                string errorMessage;
                string resultado = compraBusiness.CrearCompra(productoId, fechaString, cantidad, out errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    Console.WriteLine(resultado);
                }

                break;
            case 9:
                Console.WriteLine("Obtener una Compra");
                Console.Write("Ingrese Id de la compra: ");
                int compraId = int.Parse(Console.ReadLine());
                var compra = compraBusiness.ObtenerCompraBusiness(compraId);
                if (compra != null)
                {
                    Console.WriteLine($"Compra encontrada: {compra.fecha}, Producto ID: {compra.productoId}, Cantidad: {compra.cantidad}");
                }
                else
                {
                    Console.WriteLine("Compra no encontrada.");
                }
                break;
            case 10:
                Console.WriteLine("Creacion de usuario");
                Console.WriteLine("Ingrese Nombre del usuario");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Contraseña del usuario");
                string contraseña = Console.ReadLine();
                string contraSalt = GeneradorHashSalt.GenerarSalt(contraseña);
                int salt = GeneradorHashSalt.GetSalt();
                var nuevoUsuario = new Usuarios
                {
                    Nombre = nombre,
                    salt = salt,
                    hash = GeneradorHashSalt.GenerarHash(contraSalt)
                };
                usuariobusiness.CrearUsuarioBusiness(nuevoUsuario);

                break;
            case 11:
                Console.WriteLine("Ver Usuarios");
                var listUsuarios = usuariobusiness.ObtenerUsuariosBusiness();

                foreach (var usser in listUsuarios)
                {
                    Console.WriteLine(usser.ToString());
                }
                break;
            case 12:
                Console.WriteLine("LOGIN");
                Console.WriteLine("Ingresar Nombre de Usuario");
                string usuario = Console.ReadLine();
                Console.WriteLine("Ingresar Contraseña");
                contraseña = Console.ReadLine();

                var usuarioLogg = usuariobusiness.ObtenerUnUsuariosBusiness(usuario);   //Traigo el usuario con ese nombre
                contraseña = usuarioLogg.salt + contraseña;//Traigo el salt de ese usuario y lo concateno al la contraseña en el mismo orden que se genera
                contraseña = GeneradorHashSalt.GenerarHash(contraseña);//Genero el Hash de nuevo


                if (usuarioLogg != null && contraseña == usuarioLogg.hash)// Compruebo que el usuario no sea nulo y que el hash sea el mismo
                {
                    UsuarioGlobal.SetUsuario(usuarioLogg.UsuarioId);
                    Console.WriteLine("Usuario logueado "+usuarioLogg.ToString());
                    Console.WriteLine("Usuario Global = "+UsuarioGlobal.GetUsuario());
                }
                else
                {
                    Console.WriteLine("Usuario o contraseña Invalido");
                }
                break;
            case 13:
                Console.WriteLine("Ventas de 1 Usuario");
                Console.Write("Ingrese Id del usuario");
                int IdUsuario = int.Parse(Console.ReadLine());
                var listVentas = ventaBusiness.VentasDeUnUsuarioBusiness(IdUsuario);//traigo la lista de ventas de 1 usuario
                

                foreach (var venta2 in listVentas)
                {//Imprimo los nombres de los productos que vendio y la cantidad
                    Console.WriteLine("Venta de "+ productoBusiness.GetProducto(venta2.ProductoId).Nombre + " Cantidad " + venta2.Cantidad);
                }

                break;
            case 14:
                Console.WriteLine("Compras de 1 Usuario");
                Console.Write("Ingrese Id del usuario");
                IdUsuario = int.Parse(Console.ReadLine());
                var listCompras1uss = compraBusiness.ComprasDeUnUsuarioBusiness(IdUsuario);//traigo la lista de ventas de 1 usuario


                foreach (var compra2 in listCompras1uss)
                {//Imprimo los nombres de los productos que compro y la cantidad
                    Console.WriteLine("Venta de " + productoBusiness.GetProducto(compra2.productoId).Nombre + " Cantidad " + compra2.cantidad);
                }

                break;
            case 15:
                Console.WriteLine("Obtener Venta");
                Console.Write("Ingrese Id de la venta: ");
                int VentaId = int.Parse(Console.ReadLine());
                var venta = ventaBusiness.ObtenerVentaBusiness(VentaId);
                if (venta != null)
                {
                    Console.WriteLine($"venta encontrada: {venta.Fecha}, Producto ID: {venta.ProductoId}, Cantidad: {venta.Cantidad}");
                }
                else
                {
                    Console.WriteLine("venta no encontrada.");
                }
                break;
            case 16:
                Console.WriteLine("16. Crear Venta");
                Console.Write("Ingrese Id del producto que quiere Vender: ");
                productoId = int.Parse(Console.ReadLine());

                
                Console.Write("Ingrese la cantidad que quiere Vender: ");
                cantidad = int.Parse(Console.ReadLine());

                resultado = ventaBusiness.CrearVenta(productoId, cantidad, out errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    Console.WriteLine(errorMessage);
                }
                else
                {
                    Console.WriteLine(resultado);
                }
                break;
            case 17:
                Console.WriteLine("Eliminar Usuario");
                Console.WriteLine("Ingrese el id del Usuario");
                IdUsuario = int.Parse(Console.ReadLine());
                compraBusiness.EliminarComprasDeUnUsuarioBusiness(IdUsuario);
                ventaBusiness.EliminarVentasDeUnUsuarioBusiness(IdUsuario);
                usuariobusiness.EliminarUsuarioBusiness(IdUsuario);
                break;
            case 18:
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




*/
