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

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para EliminarUsuario.xaml
    /// </summary>
    public partial class EliminarUsuario : Window
    {
        public EliminarUsuario()
        {
            InitializeComponent();
        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            var compraBusiness = new CompraBusiness();
            var ventaBusiness = new VentaBusiness();
            var usuariobusiness = new UsuarioBusiness();

            var IdUsuario = int.Parse(textIdEliminarUsuario.Text);
            compraBusiness.EliminarComprasDeUnUsuarioBusiness(IdUsuario);
            ventaBusiness.EliminarVentasDeUnUsuarioBusiness(IdUsuario);
            usuariobusiness.EliminarUsuarioBusiness(IdUsuario);

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
