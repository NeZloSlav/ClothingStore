using System.ComponentModel.Design;
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
        
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = (Hyperlink)sender;

            if (hyperlink.Name == "HyperlinkNoAccount")
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

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            if (FormsValidation())
            {
                ClearAllValidationMarks();

                if (IsPhone)
                {
                    MessageBox.Show("Всё супер, введён телефон");

                    //var employee = EmployeeService.Employees.FirstOrDefault(u => u.Phone == TextBoxPhoneOrEmail.Text && u.Password == TextBoxPhoneOrEmail.Text);
                    //if (employee is null)
                    //{
                    //    var customer = CustomerService.Customers.FirstOrDefault(u => u.Phone == TextBoxPhoneOrEmail.Text);
                    //    if (customer is null)
                    //    {
                    //        MessageBox.Show("Такого пользователя не существует");
                    //        return;
                    //    }

                    //    CurrentUser.currentCustomer = customer;
                    //}
                    //else
                    //{
                    //    CurrentUser.currentEmployee = employee;
                    //}
                }
                else
                {
                    MessageBox.Show("Всё супер, введёна почта");

                    //var employee = EmployeeService.Employees.FirstOrDefault(u => u.Phone == TextBoxPhoneOrEmail.Text);
                    //if (employee is null)
                    //{
                    //    var customer = CustomerService.Customers.FirstOrDefault(u => u.Phone == TextBoxPhoneOrEmail.Text);
                    //    if (customer is null)
                    //    {
                    //        MessageBox.Show("Такого пользователя не существует");
                    //        return;
                    //    }
                          
                    //    CurrentUser.currentCustomer = customer;
                    //}
                    //else
                    //{
                    //    CurrentUser.currentEmployee = employee;
                    //}
                }

                MainWindow mainWindow = new MainWindow();
                NavigateClass.currentWindow.Close();
                NavigateClass.currentWindow = mainWindow; ;
                mainWindow.Show();
            }
        }

        private bool FormsValidation()
        {
            bool IsMistakesNotExist = true;

            if (TextBoxPhoneOrEmail.Text.Contains('@'))
            {
                if (!TextBoxPhoneOrEmail.Text.ValidateEmailAddress(true))
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Visible;
                    IsMistakesNotExist = false; 
                }
                else
                {
                    IsPhone = false;
                }
            }
            else
            {
                if (!TextBoxPhoneOrEmail.Text.ValidatePhoneNumber(true))
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Visible;
                    IsMistakesNotExist = false;
                }
                else
                {
                    IsPhone = true;
                }
            }

            if (!PasswordBoxPassword.Password.ValidatePassword(true))
            {
                BorderPasswordException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;

            }

            return IsMistakesNotExist;
        }

        private void ClearAllValidationMarks()
        {
            BorderPhoneOrEmailException.Visibility = Visibility.Hidden;
            BorderPasswordException.Visibility = Visibility.Hidden;
        }

        private void TextBoxPhoneOrEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPhoneOrEmail.Text.Contains('@'))
            {
                if (TextBoxPhoneOrEmail.Text.ValidateEmailAddress(false))
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Hidden;
                }
                else
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Visible;
                }
            }
            else
            {
                if (TextBoxPhoneOrEmail.Text.ValidatePhoneNumber(false))
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Hidden;
                }
                else
                {
                    BorderPhoneOrEmailException.Visibility = Visibility.Visible;
                }
            }

            
        }
    }
}
