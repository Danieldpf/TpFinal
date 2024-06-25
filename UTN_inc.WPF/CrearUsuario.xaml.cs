using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UTN_inc.Core.Business;
using UTN_inc.Core.Configuracion;
using UTN_inc.Core.Entities;

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para CrearUsuario.xaml
    /// </summary>
    public partial class CrearUsuario : Window
    {
        public CrearUsuario()
        {
            InitializeComponent();
        }

        private void Button_Crear(object sender, RoutedEventArgs e)
        {

            var usuariobusiness = new UsuarioBusiness();
            string nombre = textNombreCrearUsuario.Text;
            string contraseña = textContraseñaCrearUsuario.Password;

            string contraSalt = GeneradorHashSalt.GenerarSalt(contraseña);

            int salt = GeneradorHashSalt.GetSalt();
            var nuevoUsuario = new Usuarios
            {
                Nombre = nombre,
                salt = salt,
                hash = GeneradorHashSalt.GenerarHash(contraSalt)
            };
            usuariobusiness.CrearUsuarioBusiness(nuevoUsuario);

            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
