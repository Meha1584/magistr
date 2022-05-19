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
    /// Логика взаимодействия для WindowAccountant.xaml
    /// </summary>
    public partial class WindowAccountant : Page
    {
        Employee employee;
        TutoringCenterEntities _context;
        public WindowAccountant(Employee employee, TutoringCenterEntities _context)
        {
            InitializeComponent();
            this.employee = employee;
            this._context = _context;
            StartOptions();
        }
        public void StartOptions()
        {
            frameAcc.Navigate(new ListTeacherForAcc(employee, _context));
        }

        private void FrameTeacher(object sender, RoutedEventArgs e)
        {
            frameAcc.Navigate(new ListTeacherForAcc(employee, _context));
        }

        private void CreateReportTeacher(object sender, RoutedEventArgs e)
        {

        }
    }
}
