using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.DataEF;

var builder = WebApplication.CreateBuilder(args);   //Creacion de la app web
var connString = builder.Configuration.GetConnectionString("UTN_incConnectionString");//Busca el string de conexion


//El Scopes inyecta a todo el contexto de la aplicacion

//Repository se agrega porque ocupa business y condig porque ocupan todos
//Scoped es un request mientras este el request el scope va a hacer lo que este haciendo, no se crea otro
builder.Services.AddScoped<ProductoBusiness>();//inyeccion de siervicios de business
builder.Services.AddScoped<ProductoRepository>();

//config necesita que le pasemos el archivo de configuracion
var config = new UTN_inc.Core.Configuracion.Config()
{
    ConnectionString = connString
};



//Inyeccion de dependencias
builder.Services.AddScoped<Config>(p =>
{
    return config;
});



// Add services to the container.
builder.Services.AddControllersWithViews();         //inyecta los controladores
                                                    //cada capa debe agregar su capa inferior

var app = builder.Build();                          //genera el builder de la app

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");//esta es la ruta que usamos (creo que es el link)   / esta ruta la toma del Controlador     / hay una ruta que dirige hacia el controlador

app.Run();
