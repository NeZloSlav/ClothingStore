using System.Windows;
using System.Windows.Controls;
using ClothingStore.ClassHelper;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.logRegFrame.Navigate(new RegistrationPage());
        }

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
