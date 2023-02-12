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
        private bool IsPhone;

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

                if (IsPhone)
                {
                    MessageBox.Show("Всё супер, введён телефон");
                }
                else
                {
                    MessageBox.Show("Всё супер, введёна почта");
                }
            }
        }

        private bool FormsValidation()
        {
            bool IsMistakesNotExist = true;

            if (tbxPhoneOrEmail.Text.Contains('@'))
            {
                if (!tbxPhoneOrEmail.Text.ValidateEmailAddress(true))
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Visible;
                    IsMistakesNotExist = false;
                }
                else
                {
                    IsPhone = false;
                }
            }
            else
            {
                if (!tbxPhoneOrEmail.Text.ValidatePhoneNumber(true))
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Visible;
                    IsMistakesNotExist = false;
                }
                else
                {
                    IsPhone = true;
                }
            }

            if (!tbxPassword.Password.ValidatePassword(true))
            {
                brdPasswordExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;

            }

            return IsMistakesNotExist;
        }

        private void ClearAllValidationMarks()
        {
            brdPhoneOrEmailExcep.Visibility = Visibility.Hidden;
            brdPasswordExcep.Visibility = Visibility.Hidden;
        }

        private void tbxPhoneOrEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPhoneOrEmail.Text.Contains('@'))
            {
                if (tbxPhoneOrEmail.Text.ValidateEmailAddress(false))
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Hidden;
                }
                else
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (tbxPhoneOrEmail.Text.ValidatePhoneNumber(false))
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Hidden;
                }
                else
                {
                    brdPhoneOrEmailExcep.Visibility = Visibility.Visible;
                }
            }

            
        }
    }
}
