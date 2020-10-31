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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegistroPedidosSuplidores.UI.Consulta;
using RegistroPedidosSuplidores.UI.Registro;
using RegistroPedidosSuplidores.BLL;

namespace RegistroPedidosSuplidores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RegistroOrdenesButton_Click(object sender, RoutedEventArgs e)
        {
            rPedidos rPedidos = new rPedidos();
            rPedidos.Show();

        }
        private void ConsultaOrdenesButton_Click(object sender, RoutedEventArgs e)
        {
            cPedidos cPedidos = new cPedidos();
            cPedidos.Show(); 

        }

        private void AyudaMenu_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
