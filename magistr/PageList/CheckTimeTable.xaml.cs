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
    /// Логика взаимодействия для CheckTimeTable.xaml
    /// </summary>
    public partial class CheckTimeTable : Page
    {
        Employee employee;
        public CheckTimeTable(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            checkName.Content = $"Расписание преподавателя {employee.fio}";
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
