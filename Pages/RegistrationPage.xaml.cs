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

        private void tbxPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPhone.Text.ValidatePhoneNumber(false))
            {
                brdPhoneExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdPhoneExcep.Visibility = Visibility.Visible;
            }
        }

        private void tbxEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxEmail.Text.ValidateEmailAddress(false))
            {
                brdEmailExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdEmailExcep.Visibility = Visibility.Visible;
            }
        }

        private void tbxSurname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxSurname.Text.ValidateTextField(false))
            {
                brdSurnameExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdSurnameExcep.Visibility = Visibility.Visible;
            }
        }

        private void tbxName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxName.Text.ValidateTextField(false))
            {
                brdNameExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdNameExcep.Visibility = Visibility.Visible;
            }
        }

        private void tbxPatronymic_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbxPatronymic.Text.ValidateTextField(false))
            {
                brdPatronymicExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdPatronymicExcep.Visibility = Visibility.Visible;
            }
        }

        private void pswPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (pswPassword.Password.ValidatePassword(false))
            {
                brdPasswordExcep.Visibility = Visibility.Hidden;
            }
            else
            {
                brdPasswordExcep.Visibility = Visibility.Visible;
            }
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (FormsValidation())
            {
                MessageBox.Show("Всё просто замечательно");
                ClearAllValidationMarks();
            }
        }

        private bool FormsValidation()
        {
            bool IsMistakesNotExist = true;

            if (!tbxPhone.Text.ValidatePhoneNumber(true))
            {
                brdPhoneExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!tbxEmail.Text.ValidateEmailAddress(true))
            {
                brdEmailExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!tbxSurname.Text.ValidateTextField(true))
            {
                brdSurnameExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!tbxName.Text.ValidateTextField(true))
            {
                brdNameExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (!pswPassword.Password.ValidatePassword(true))
            {
                brdPasswordExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }

            if (pswRePassword.Password != pswPassword.Password)
            {
                brdPasswordExcep.Visibility = Visibility.Visible;
                brdRePasswordExcep.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;
            }


            return IsMistakesNotExist;
        }

        private void ClearAllValidationMarks()
        {
            brdEmailExcep.Visibility = Visibility.Hidden;
            brdNameExcep.Visibility = Visibility.Hidden;
            brdPasswordExcep.Visibility = Visibility.Hidden;
            brdPatronymicExcep.Visibility = Visibility.Hidden;
            brdPhoneExcep.Visibility = Visibility.Hidden;
            brdRePasswordExcep.Visibility = Visibility.Hidden;
            brdSurnameExcep.Visibility = Visibility.Hidden;
        }
    }
}
