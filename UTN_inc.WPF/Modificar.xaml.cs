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
using static System.Runtime.InteropServices.JavaScript.JSType;
using UTN_inc.Core.Business;

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        public Modificar()
        {
            InitializeComponent();
        }

        private void Button_Modificar(object sender, RoutedEventArgs e)
        {
            var productoBusiness = new ProductoBusiness();
            var categoriaBusiness = new CategoriaBusiness();
            int buscarId = int.Parse(textIdBusqueda.Text);
            var productoObetenido = productoBusiness.GetProducto(buscarId);

            string nombre = textNombreBusqueda.Text;

            int categoria = int.Parse(textCategoriaBusqueda.Text);

            bool habilitado = checkBusqueda.IsChecked ?? false;

            productoObetenido.Nombre = nombre;
            productoObetenido.CategoriaId = categoria;

            if (habilitado == true)
            {
                productoObetenido.Habilitado = true;
            }
            else if (habilitado == false)
            {
                productoObetenido.Habilitado = false;
            }

            var result = productoBusiness.UpdateBusiness(productoObetenido);
            if (result.Success)
            {
                productoObetenido = productoBusiness.GetProducto(buscarId);
                var categoriaDeProd = categoriaBusiness.GetCategoriaBus(productoObetenido.CategoriaId);
                productoObetenido.Categoria = categoriaDeProd;
            }


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
