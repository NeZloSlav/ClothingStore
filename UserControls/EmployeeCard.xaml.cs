using ClothingStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClothingStore.UserControls
{
    /// <summary>
    /// Логика взаимодействия для EmployeeCard.xaml
    /// </summary>
    public partial class EmployeeCard : UserControl 
    {
        public EmployeeCard()
        {
            InitializeComponent();
        }

        public string LastName
        {
            get { return (string)GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        public static readonly DependencyProperty LastNameProperty = DependencyProperty.Register("LastName", typeof(string), typeof(EmployeeCard));

        public string FirstName
        {
            get { return (string) GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }

        public static readonly DependencyProperty FirstNameProperty = DependencyProperty.Register("FirstName", typeof(string), typeof(EmployeeCard));

        public string Patronymic
        {
            get { return (string)GetValue(PatronymicProperty); }
            set { SetValue(PatronymicProperty, value); }
        }

        public static readonly DependencyProperty PatronymicProperty = DependencyProperty.Register("Patronymic", typeof(string), typeof(EmployeeCard));

        public string Phone
        {
            get { return (string)GetValue(PhoneProperty); }
            set { SetValue(PhoneProperty, value); }
        }

        public static readonly DependencyProperty PhoneProperty = DependencyProperty.Register("Phone", typeof(string), typeof(EmployeeCard));

        public Employee EmployeeInfo
        {
            get { return (Employee)GetValue(EmployeeInfoProperty); }
            set { SetValue(EmployeeInfoProperty, value); }
        }

        public static readonly DependencyProperty EmployeeInfoProperty = DependencyProperty.Register("EmployeeInfo", typeof(Employee), typeof(EmployeeCard));


    }
}
