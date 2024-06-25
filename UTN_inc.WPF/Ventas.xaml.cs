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
    /// Lógica de interacción para Ventas.xaml
    /// </summary>
    public partial class Ventas : Window
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void Button_Vender(object sender, RoutedEventArgs e)
        {
            try
            {
                var compraBusiness = new CompraBusiness();
                var ventaBusiness = new VentaBusiness();

                // Validación de ProductoId
                if (!int.TryParse(textProductoIdVentas.Text, out int productoId))
                {
                    MessageBox.Show("El ID del producto debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Cantidad
                if (!int.TryParse(textCantidadVentas.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Buscar compra por producto
                var idCompra = compraBusiness.BuscarCompraPorProducto(productoId);

                if (idCompra != null)
                {
                    var compraDe1Producto = compraBusiness.ObtenerCompraBusiness(idCompra.compraId);
                    if (compraDe1Producto.cantidad >= cantidad) // Verificar que haya suficiente stock
                    {
                        string errorMessage;
                        string resultado = ventaBusiness.CrearVenta(productoId, cantidad, out errorMessage);

                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            MessageBox.Show(errorMessage, "Error al crear venta", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            MessageBox.Show(resultado, "Venta creada", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Stock insuficiente.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Compra inexistente para el producto.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                // Abrir ventana principal y cerrar la actual
                MainWindow ventanaPrincipal = new MainWindow();
                ventanaPrincipal.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void Button_Atras(object sender, RoutedEventArgs e)
        {
            MainWindow ventanaPrincipal = new MainWindow();
            ventanaPrincipal.Show();
            this.Close();
        }

    }
}
