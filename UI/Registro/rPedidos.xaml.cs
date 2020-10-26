using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroPedidosSuplidores.BLL;
using RegistroPedidosSuplidores.Entidades;


namespace RegistroPedidosSuplidores.UI.Registro
{
    /// <summary>
    /// Lógica de interacción para rPedidos.xaml
    /// </summary>
    public partial class rPedidos : Window
    {
        private Ordenes ordenes = new Ordenes();
        public rPedidos()
        {
            InitializeComponent();
            this.DataContext = ordenes;
           
            SuplidorIdComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "SuplidorId";
            SuplidorIdComboBox.DisplayMemberPath = "Nombres";

           
            ProductoIdComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductoIdComboBox.SelectedValuePath = "ProductoId";
            ProductoIdComboBox.DisplayMemberPath = "Descripcion";
        }
      
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = ordenes;
            SuplidorIdComboBox.SelectedIndex = ordenes.SuplidorId;
        }
       
        private void Limpiar()
        {
            this.ordenes = new Ordenes();
            this.DataContext = ordenes;
            this.ordenes.Fecha = DateTime.Now;
        }
       
        private bool Validar()
        {
            bool Validado = true;
            
            if (PedidoIdTextbox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show(" Debe ingresar el id pedido, Verifique e intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return Validado;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Ordenes encontrado = OrdenesBLL.Buscar(ordenes.OrdenId);

            if (encontrado != null)
            {
                ordenes = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show($"Este pedido no fue encontrado.\n\nAsegurese que existe o cree uno nuevo.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                PedidoIdTextbox.Clear();
                PedidoIdTextbox.Focus();
            }
        }
        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuplidorIdComboBox.Text == string.Empty)
            {
                MessageBox.Show($"El campo Suplidor Id esta vacio.\n\nSeleccione un Suplidor.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                 SuplidorIdComboBox.IsDropDownOpen = true;
                return;
            } 
            Productos producto = (Productos)ProductoIdComboBox.SelectedItem; 
            var filaDetalle = new OrdenesDetalle
            {
               
                OrdenId = this.ordenes.OrdenId,
                ProductoId = Convert.ToInt32(ProductoIdComboBox.SelectedValue.ToString()),
                productos = (Productos)ProductoIdComboBox.SelectedItem,
                Cantidad = Convert.ToInt32(CantidadTextBox.Text)
            };
           
           ordenes.Monto += producto.Costo * int.Parse(CantidadTextBox.Text);
            this.ordenes.Detalle.Add(filaDetalle);
            Cargar();

            ProductoIdComboBox.SelectedIndex = -1;
            CantidadTextBox.Clear();
            CantidadTextBox.Focus();
        }
        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                 var detalle = (OrdenesDetalle)DetalleDataGrid.SelectedItem;

                ordenes.Monto = ordenes.Monto - (detalle.productos.Costo * (int)detalle.Cantidad);
                ordenes.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }
       
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (!Validar())
                    return;

                var paso = OrdenesBLL.Guardar(this.ordenes);
                if (paso)
                {
                    Limpiar();
                    MessageBox.Show("Pedido Guadado Correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se ha podido guadar, verifique e intente de nuevo", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            {
                if (OrdenesBLL.Eliminar(Utilidades.ToInt(PedidoIdTextbox.Text)))
                {
                    Limpiar();
                    MessageBox.Show("Registro Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("No se pudo eliminar por que el pedido no existe", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

