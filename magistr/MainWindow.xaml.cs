using System;
using System.Collections.Generic;
using System.Linq;
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

namespace magistr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TutoringCenterEntities _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new TutoringCenterEntities();
        }

        private void GoApp(object sender, RoutedEventArgs e)
        {
            int login = Convert.ToInt32(inputLogin.Text);
            string password = inputPassword.Password;
            if (_context.Employee.Any(x=> x.codeEmployee == login && x.password.Equals(password)) )
            {
                Employee employee = _context.Employee.ToList().Find(x => x.codeEmployee == login);
                MenuWindow menuWindow = new MenuWindow(employee);
                inputPassword.Password = "";
                inputLogin.Text = "";
                this.Hide();
                menuWindow.Show();
                menuWindow.Closed += MenuWindow_Closed;
            }
            else
            {
                MessageBox.Show("Неверные входные данные", "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MenuWindow_Closed(object sender, EventArgs e)
        {
            MenuWindow menWin = sender as MenuWindow;
            if (menWin.CheckClose == false)
                this.Close();
            else
                this.Visibility = Visibility.Visible;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
