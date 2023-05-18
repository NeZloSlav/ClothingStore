using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using ClothingStore.ClassHelper;
using ClothingStore.Models;

namespace ClothingStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private bool isPhone;
        private List<string> OldValues, NewValues;

        public LoginPage()
        {
            InitializeComponent();

            OldValues = new List<string>();
            NewValues = new List<string>();
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
            NewValues.AddRange( new string[] { TextBoxPhoneOrEmail.Text, PasswordBoxPassword.Password });

            if (CheckingForRepeat())
            {
                if (FormsValidation())
                {
                    ClearValidationMarks();

                    Login();
                }
            }
        }

        private void Login()
        {
            GetUserFromDB();

            if (UserData.CurrentUser != null)
            {
                UserData.CurrentEmployee = EFClass.Context.Employee.FirstOrDefault(e => e.UserId == UserData.CurrentUser.UserId);

                if (UserData.CurrentEmployee != null)
                {
                    UserData.CurrentClient = EFClass.Context.Client.FirstOrDefault(e => e.UserId == UserData.CurrentUser.UserId);
                }

                GoToNextWindow();
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно. Убедитесь в корректности данных.");
            }
        }

        private void GetUserFromDB()
        {
            User userAuth = new User();

            if (isPhone)
            {
                userAuth = EFClass.Context.User.FirstOrDefault(u => u.PhoneNumber == TextBoxPhoneOrEmail.Text && u.Password == PasswordBoxPassword.Password);
            }
            else
            {
                userAuth = EFClass.Context.User.FirstOrDefault(u => u.Email == TextBoxPhoneOrEmail.Text && u.Password == PasswordBoxPassword.Password);
            }

            if (userAuth != null)
            {
                UserData.CurrentUser = userAuth;
            }
        }

        private void GoToNextWindow()
        {
            MainWindow mainWindow = new MainWindow();
            NavigateClass.currentWindow.Close();
            NavigateClass.currentWindow = mainWindow; ;
            mainWindow.Show();
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
                    isPhone = false;
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
                    isPhone = true;
                }
            }

            if (!PasswordBoxPassword.Password.ValidatePassword(true))
            {
                BorderPasswordException.Visibility = Visibility.Visible;
                IsMistakesNotExist = false;

            }

            return IsMistakesNotExist;
        }

        private void ClearValidationMarks()
        {
            BorderPhoneOrEmailException.Visibility = Visibility.Hidden;
            BorderPasswordException.Visibility = Visibility.Hidden;
        }

        private bool CheckingForRepeat()
        {
            if (OldValues.SequenceEqual(NewValues))
            {
                NewValues.Clear();
                return false;
            }

            OldValues.Clear();
            NewValues.ForEach(x => OldValues.Add(x));
            NewValues.Clear();

            return true;
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
