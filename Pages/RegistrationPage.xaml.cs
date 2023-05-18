using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using ClothingStore.ClassHelper;
using ClothingStore.Models;

namespace ClothingStore.Pages
{
    public partial class RegistrationPage : Page
    {
        private List<string> OldValues, NewValues;

        public RegistrationPage()
        {
            InitializeComponent();

            OldValues = new List<string>();
            NewValues = new List<string>();
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
            NewValues.AddRange(new string[] {TextBoxPhone.Text, TextBoxEmail.Text, TextBoxSurname.Text, TextBoxName.Text, TextBoxPatronymic.Text, PasswordBoxPassword.Password, PasswordBoxRePassword.Password});

            if (CheckingForRepeat())
            {
                if (FormsValidation())
                {
                    MessageBox.Show("Всё просто замечательно");
                    ClearAllValidationMarks();

                    Registration();

                    
                }
            }
        }

        private void Registration()
        {
            if (!IsAlreadySignIn())
            {

                var user = new User
                {
                    LastName = TextBoxSurname.Text,
                    FirstName = TextBoxName.Text,
                    Patronymic = TextBoxPatronymic.Text,
                    Email = TextBoxEmail.Text,
                    PhoneNumber = TextBoxPhone.Text,
                    Password = PasswordBoxPassword.Password,
                    Birthday = DataPickerBirthday.SelectedDate.Value,
                    GenderId = GetGenderId(),
                };

                EFClass.Context.User.Add(user);
                EFClass.Context.SaveChanges();

                UserData.CurrentUser = user;

                var client = new Client
                {
                    UserId = user.UserId
                };

                EFClass.Context.Client.Add(client);
                EFClass.Context.SaveChanges();

                UserData.CurrentClient = client;

                GoToNextWindow();
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными уже зарегистрирован.");
            }
        }

        private bool IsAlreadySignIn()
        {
            User user = EFClass.Context.User.FirstOrDefault(u => u.Email == TextBoxEmail.Text && u.PhoneNumber == TextBoxPhone.Text);

            if (user != null)
            {
                return true;
            }

            return false;
        }

        private void GoToNextWindow()
        {
            MainWindow mainWindow = new MainWindow();
            NavigateClass.currentWindow.Close();
            NavigateClass.currentWindow = mainWindow; ;
            mainWindow.Show();
        }

        private int GetGenderId()
        {
            if ((bool)ToggleButtonMale.IsChecked)
            {
                return 1; //равно значению в базе данных "мужской"
            }
            else if ((bool)ToggleButtonFemale.IsChecked)
            {
                return 2; //равно значению в базе данных "женский"
            }
            else 
            {
                return 3; //равно значению в базе данных "не указано"
            }
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
