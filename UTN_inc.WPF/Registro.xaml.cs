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
using UTN_inc.Core.DataEF;
using UTN_inc.Core.Entities;

namespace UTN_inc.WPF
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        UTN_incContext _context;

        public Registro()
        {
            InitializeComponent();
            _context = new UTN_incContext(new Core.Configuracion.Config());
            CargarDatosVenta();
            CargarDatosCompra();

        }

        private void CargarDatosVenta()
        {
            var productosVentas = _context.ventas.ToList();
            listViewVentas.ItemsSource = productosVentas;

        }

        private void CargarDatosCompra()
        {
            var productosCompras = _context.compras.ToList();
            listViewCompras.ItemsSource = productosCompras;
        }

        private void Button_Eliminar_Compra(object sender, RoutedEventArgs e)
        {
            var compraBusiness = new CompraBusiness();
            int compraId = int.Parse(textCompraId.Text);
            compraBusiness.EliminarCompraBusiness(compraId);
            Registro nuevoRegistro = new Registro();
            nuevoRegistro.Show();
            this.Close();
        }

        private void Button_Eliminar_Venta(object sender, RoutedEventArgs e)
        {
            var ventaBusiness = new VentaBusiness();
            int VentaId = int.Parse(textVentaId.Text);
            ventaBusiness.EliminarVentaBusiness(VentaId);
            Registro nuevoRegistro = new Registro();
            nuevoRegistro.Show();
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
