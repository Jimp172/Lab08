using Business;
using Entity1;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "ProductId" || textBox.Text == "Name" || textBox.Text == "Price" || textBox.Text == "Stock" || textBox.Text == "Active")
            {
                textBox.Text = string.Empty;
            }
        }

        private void Button_Click_Listar(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            var productList = business.GetAllProducts();
            McDataGrid.ItemsSource = productList;
        }
        private void Button_Click_Crear(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            string name = txtName1.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            Product newProduct = new Product
            {
                Name = name,
                Price = price,
                Stock = stock
            };
            business.CreateProduct(newProduct);
        }

        private void Button_Click_Buscar(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            string name = txtName.Text;
            var productList = business.GetByName(name);
            McDataGrid.ItemsSource = productList;
        }

        private void Button_Click_Actualizar(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();
            int productId = Convert.ToInt32(txtProductIdU.Text);
            string name = txtNameU.Text;
            decimal price = Convert.ToDecimal(txtPriceU.Text);
            int stock = Convert.ToInt32(txtStockU.Text);
            bool active = Convert.ToBoolean(txtActiveU.Text);


            Product product = new Product
            {
                ProductId = productId,
                Name = name,
                Price = price,
                Stock = stock,
                Active = active
            };

            business.UpdateProduct(product);
        }

        private void Button_Click_Eliminar(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();

            int productId = Convert.ToInt32(txtProductIdD.Text);
            Product product = new Product
            {
                ProductId = productId
            };
            business.DeleteProduct(product);
        }

        private void Button_Click_Activar(object sender, RoutedEventArgs e) 
        {
            BProduct business = new BProduct();

            int productId = Convert.ToInt32(txtProductIdAD.Text);
            Product product = new Product
            {
                ProductId = productId
            };

            business.ActiveProduct(product);
        }
    }

    /*
      public partial class MainWindow : Window
    {
        private BProduct productManager;

        public MainWindow()
        {
            InitializeComponent();
            productManager = new BProduct();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BProduct business = new BProduct();

            List<Product> productList = productManager.GetAllProducts(); // O productManager.Get() si es tu caso

            // Asigna la lista de productos como origen de datos para el DataGrid
            McDataGrid.ItemsSource = productList;

        }
    }
    */
}
