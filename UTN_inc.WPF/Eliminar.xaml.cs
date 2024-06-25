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
    /// Lógica de interacción para Eliminar.xaml
    /// </summary>
    public partial class Eliminar : Window
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {

            var productoBusiness = new ProductoBusiness();
            int buscarId = int.Parse(textProductoIdEliminar.Text);
            var result = productoBusiness.DeleteAsync(buscarId);

            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.Show();
            this.Close();
        }

        private void Button_Atras(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.Show();
            this.Close();
        }
    }
}
