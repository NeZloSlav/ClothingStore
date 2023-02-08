using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ClothingStore.ClassHelper;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.logRegFrame.Navigate(new LoginPage());
        }

        private void tglbtn_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton tglButton = (ToggleButton)sender;

            if (tglButton.Name == "tglbtnMale")
            {
                tglbtnFemale.IsChecked = false;
            }
            else
            {
                tglbtnMale.IsChecked = false;
            }
        }
    }
}
