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

namespace magistr.PageList
{
    /// <summary>
    /// Логика взаимодействия для ListTeacherForAcc.xaml
    /// </summary>
    public partial class ListTeacherForAcc : Page
    {
        Employee employee;
        TutoringCenterEntities _context;

        public ListTeacherForAcc(Employee employee, TutoringCenterEntities _context)
        {
            InitializeComponent();
            this.employee = employee;
            this._context = _context;
            StartOptions();
        }
        public void StartOptions()
        {
            nameAcc.Content = $"Здравствуйте {employee.fio}.";
            dataTeacher.ItemsSource = _context.Employee.Where(x => x.position == 2 && x.fio != null).ToList();
        }

        private void CheckTimeTable(object sender, RoutedEventArgs e)
        {
            if (dataTeacher.SelectedItems.Count == 1)
            {
                Employee currentEmployee = dataTeacher.SelectedItem as Employee;
                NavigationService.Navigate(new CheckTimeTable(currentEmployee));
            }
            else
            {
                MessageBox.Show("Выберите одного преподавателя");
            }
        }

        private void CheckInfoTeacher(object sender, RoutedEventArgs e)
        {
            Employee currentEmployee = dataTeacher.SelectedItem as Employee;
            NavigationService.Navigate(new CheckTeacher(currentEmployee, _context));
        }
    }
}
