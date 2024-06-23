using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.Core.DataEF
{
    //el nombre del contexto esta basado en la BD
    public class UTN_incContext : DbContext
    {
        private readonly string CONNECTIONSTRING = "Persist Security Info =True;Initial Catalog=UTN_inc; Data Source=localhost; Application Name=DemoApp2; Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";


        private readonly Config _config;//aca con el readonly nadie lo puede cambiar / solamente en el constructor
                                        //Inyecion 



        public UTN_incContext(Config config)//cuando se crea un repo hay que pasarle la congiguracion
        {
            _config = config;//esto toma el valor que le pasemos por configuracion 
        }




        //esto mapea el nombre de una tabla que se llame asi en mi BD
        //Mapea el nombre(productos) a una tabla que se llame asi(Producto) en la Base de Datos. Si no se llama Asi (Producto) da error
        public DbSet<Producto> productos { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<Compra> compras { get; set; }
        public DbSet<Venta> ventas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTIONSTRING);//que use SqlServer porque es el que tenemos instalado / paso el conecctionString por configuracion
            //optionsBuilder.UseSqlServer(_config.ConnectionString);
        }


    }
}
