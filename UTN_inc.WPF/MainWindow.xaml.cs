using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTN_inc.Core.DataEF;


namespace UTN_inc.WPF
{

    public partial class MainWindow : Window
    {

        private UTN_incContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new UTN_incContext(new Core.Configuracion.Config());
            LoadData();
        }

        private void LoadData()
        {
            _context.productos.Load();

            dataGrid.ItemsSource = _context.productos.Local.ToBindingList();
        }
        private void dataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            _context.SaveChanges();
        }


        //BOTONES
        private void Button_Agregar(object sender, RoutedEventArgs e)
        {
            Agregar ventanaAgregar = new Agregar();
            ventanaAgregar.Show();
            this.Close();
        }

        private void Button_Compras(object sender, RoutedEventArgs e)
        {
            Compras ventanaCompras = new Compras();
            ventanaCompras.Show();
            this.Close();
        }

        private void Button_Ventas(object sender, RoutedEventArgs e)
        {
            Ventas ventanaVentas = new Ventas();
            ventanaVentas.Show();
            this.Close();
        }

        private void Button_Modificar(object sender, RoutedEventArgs e)
        {
            Modificar ventanaModificar = new Modificar();
            ventanaModificar.Show();
            this.Close();
        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            Eliminar ventanaEliminar = new Eliminar();
            ventanaEliminar.Show();
            this.Close();
        }

        private void Button_Registro(object sender, RoutedEventArgs e)
        {
            Registro ventanaRegistro = new Registro();
            ventanaRegistro.Show();
            this.Close();
        }
    }
}