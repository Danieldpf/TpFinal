using Microsoft.EntityFrameworkCore;
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
using UTN_inc.Core.DataEF;

namespace UTN_inc.WPF
{
    public partial class VerUsuarios : Window
    {
        UTN_incContext _context;
        public VerUsuarios()
        {
            InitializeComponent();

            _context = new UTN_incContext(new Core.Configuracion.Config());
            CargarDatosUsuarios();
        }

        private void CargarDatosUsuarios()
        {
            var listaUsuarios = _context.usuarios.ToList();
            listViewUsuarios.ItemsSource = listaUsuarios;
        }

        private void Button_Salir(object sender, RoutedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            this.Close();
        }
    }
}
