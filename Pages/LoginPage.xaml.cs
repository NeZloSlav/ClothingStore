using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
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
        
        private void hlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = (Hyperlink)sender;

            if (hyperlink.Name == "hlinkNoAccount")
            {
                NavigateClass.logRegFrame.Navigate(new RegistrationPage());
            }
            else
            {
                MainWindow mainWin = new MainWindow();
                mainWin.Show();
                NavigateClass.currentWindow.Close();
            }
        }

        
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (FormsValidation())
            {
                ClearAllValidationMarks();
                MessageBox.Show("Всё гуд");
            }
        }

        private bool FormsValidation()
        {
            bool IsMistakesNotExist = true;

            if (!tbxNumberOrEmail.Text.ValidatePhoneNumber(true))
            {
                brdNumberOrEmailExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!tbxPassword.Password.ValidatePassword())
            {
                brdPasswordExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;

            }

            return IsMistakesNotExist;
        }

        private void ClearAllValidationMarks()
        {
            brdNumberOrEmailExcep.Visibility = Visibility.Hidden;
            brdPasswordExcep.Visibility = Visibility.Hidden;
        }

        private void tbxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxNumberOrEmail.Text.ValidatePhoneNumber(false))
            {
                brdNumberOrEmailExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdNumberOrEmailExcep.Visibility = Visibility.Visible;
            }
        }
    }
}
