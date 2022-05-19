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
using System.Windows.Shapes;

namespace magistr
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public bool CheckClose = false;
        TutoringCenterEntities _context;
        Employee employee;
        
        public MenuWindow(Employee employee)
        {
            InitializeComponent();
            _context = new TutoringCenterEntities();
            this.employee = employee;
            this.WindowState = WindowState.Maximized;
            FrameChoice();
        }
        public void FrameChoice()
        {
            if (employee.position == 1)
            {
                frame.Navigate(new PageList.WindowAccountant(employee, _context));
            }
            else
            {
                frame.Navigate(new PageList.CheckInfoForTeacherPage(employee, _context, this));
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            CheckClose = true;
            Close();
        }
    }
}
