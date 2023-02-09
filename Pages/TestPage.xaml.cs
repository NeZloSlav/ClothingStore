using ClothingStore.ClassHelper;
using System.Collections.Generic;
using System.Windows.Controls;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetListProduct()
        {
            //List<Product> products = new List<Product>();
            //products = EFClass.Content.Product.ToList();

            //lvProduct.ItemsSource = EFClass.Context.Product.ToList();


        }
    }
}
