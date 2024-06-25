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
using UTN_inc.Core.Entities;

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para Agregar.xaml
    /// </summary>
    public partial class Agregar : Window
    {

        public Agregar()
        {
            InitializeComponent();

        }

        private void Button_Agregar(object sender, RoutedEventArgs e)
        {
            
            string nombre = textNombreAgregar.Text;
            int Idcategoria = int.Parse(textCategoriaAgregar.Text);
            bool habilitado = checkHabilitado.IsChecked ?? false;
            bool habilitadoReal = false;

            if (habilitado == true)
            {
                habilitadoReal = true;
            }
            else if (habilitado == false )
            {
                habilitadoReal = false;
            }
            var productoBusiness = new ProductoBusiness();
            var nuevoProducto = new Producto { Nombre = nombre, CategoriaId = Idcategoria, Habilitado = habilitadoReal };
            productoBusiness.CrearProductoBusiness(nuevoProducto);

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
