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

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Ingresar(object sender, RoutedEventArgs e)
        {
            try
            {
                var usuariobusiness = new UsuarioBusiness();
                string usuario = textNombreLogin.Text;
                string contraseña = textContraseñaLogin.Password;

                var usuarioLogg = usuariobusiness.ObtenerUnUsuariosBusiness(usuario);

                if (usuarioLogg == null)
                {
                    MessageBox.Show("Usuario o contraseña inválidos.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                contraseña = usuarioLogg.salt + contraseña;
                contraseña = GeneradorHashSalt.GenerarHash(contraseña);

                if (contraseña == usuarioLogg.hash)
                {
                    UsuarioGlobal.SetUsuario(usuarioLogg.UsuarioId);
                    MessageBox.Show("¡Bienvenido!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    MainWindow ventanaPrincipal = new MainWindow();
                    ventanaPrincipal.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña inválidos.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Manejo de cualquier excepción inesperada
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Eliminar_Usuario(object sender, RoutedEventArgs e)
        {
            EliminarUsuario ventanaEliminarUsuario = new EliminarUsuario();
            ventanaEliminarUsuario.Show();
            this.Close();
        }

        private void Button_Ver_Usuario(object sender, RoutedEventArgs e)
        {
            VerUsuarios ventanaVerUsuarios = new VerUsuarios();
            ventanaVerUsuarios.Show();
            this.Close();
        }

        private void Button_Crear_Usuario(object sender, RoutedEventArgs e)
        {
            CrearUsuario ventanaCrearUsuario = new CrearUsuario();
            ventanaCrearUsuario.Show();
            this.Close();
        }
    }
}
