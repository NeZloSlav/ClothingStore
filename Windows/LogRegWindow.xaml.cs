using System;
using System.Windows;
using System.Windows.Input;
using ClothingStore.ClassHelper;
namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для LogRegWindow.xaml
    /// </summary>
    public partial class LogRegWindow : Window
    {
        public LogRegWindow()
        {
            InitializeComponent();

            NavigateClass.logRegFrame = frmLogReg;
            NavigateClass.logRegFrame.Navigate(new Pages.LoginPage());

            NavigateClass.currentWindow = this;


        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
