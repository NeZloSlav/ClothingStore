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

        private void HyperlinkAlreadySignIn_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.logRegFrame.Navigate(new LoginPage());
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;

            if (toggleButton.Name == "ToggleButtonMale")
            {
                ToggleButtonFemale.IsChecked = false;
            }
            else
            {
                ToggleButtonMale.IsChecked = false;
            }
        }

        private void TextBoxPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPhone.Text.ValidatePhoneNumber(false))
            {
                BorderPhoneException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderPhoneException.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text.ValidateEmailAddress(false))
            {
                BorderEmailException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderEmailException.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxSurname.Text.ValidateTextField(false))
            {
                BorderSurnameException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderSurnameException.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxName.Text.ValidateTextField(false))
            {
                BorderNameException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderNameException.Visibility = Visibility.Visible;
            }
        }

        private void TextBoxPatronymic_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPatronymic.Text.ValidateTextField(false))
            {
                BorderPatronymicException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderPatronymicException.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxPassword.Password.ValidatePassword(false))
            {
                BorderPasswordException.Visibility = Visibility.Hidden;
            }
            else
            {
                BorderPasswordException.Visibility = Visibility.Visible;
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (FormsValidation())
            {
                MessageBox.Show("Всё просто замечательно");
                ClearAllValidationMarks();
                MainWindow mainWindow = new MainWindow();
                NavigateClass.currentWindow.Close();
                mainWindow.Show();
            }
        }

        private bool FormsValidation()
        {
            bool IsMistakesNotExist = true;

            if (!TextBoxPhone.Text.ValidatePhoneNumber(true))
            {
                BorderPhoneException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!TextBoxEmail.Text.ValidateEmailAddress(true))
            {
                BorderEmailException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!TextBoxSurname.Text.ValidateTextField(true))
            {
                BorderSurnameException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!TextBoxName.Text.ValidateTextField(true))
            {
                BorderNameException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!PasswordBoxPassword.Password.ValidatePassword(true))
            {
                BorderPasswordException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (PasswordBoxRePassword.Password != PasswordBoxPassword.Password)
            {
                BorderPasswordException.Visibility = Visibility.Visible;
                BorderRePasswordException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }


            return IsMistakesNotExist;
        }

        private void ClearAllValidationMarks()
        {
            BorderEmailException.Visibility = Visibility.Hidden;
            BorderNameException.Visibility = Visibility.Hidden;
            BorderPasswordException.Visibility = Visibility.Hidden;
            BorderPatronymicException.Visibility = Visibility.Hidden;
            BorderPhoneException.Visibility = Visibility.Hidden;
            BorderRePasswordException.Visibility = Visibility.Hidden;
            BorderSurnameException.Visibility = Visibility.Hidden;
        }
    }
}
