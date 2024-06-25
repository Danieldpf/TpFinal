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
    /// Lógica de interacción para Compras.xaml
    /// </summary>
    public partial class Compras : Window
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void Button_Comprar(object sender, RoutedEventArgs e)
        {
            try
            {
                var compraBusiness = new CompraBusiness();

                // Validación de ProductoId
                if (!int.TryParse(textProductoIdCompras.Text, out int productoId))
                {
                    MessageBox.Show("El ID del producto debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Validación de Fecha
                if (datePickerCompras.SelectedDate == null)
                {
                    MessageBox.Show("Por favor, seleccione una fecha.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                DateTime selectedDate = datePickerCompras.SelectedDate.Value;
                string fechaString = selectedDate.ToString("dd/MM/yyyy");

                // Validación de Cantidad
                if (!int.TryParse(textCantidadCompras.Text, out int cantidad))
                {
                    MessageBox.Show("La cantidad debe ser un número válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Crear Compra
                string errorMessage;
                string resultado = compraBusiness.CrearCompra(productoId, fechaString, cantidad, out errorMessage);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show($"Error al crear la compra: {errorMessage}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("¡Compra realizada con éxito!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Abrir ventana principal y cerrar la actual
                    MainWindow ventanaPrincipal = new MainWindow();
                    ventanaPrincipal.Show();
                    this.Close();
                }
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
