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
    /// Логика взаимодействия для CheckTeacher.xaml
    /// </summary>
    public partial class CheckTeacher : Page
    {
        TutoringCenterEntities _context;
        Employee _currentEmployee;
        public CheckTeacher(Employee employee, TutoringCenterEntities _context)
        {
            InitializeComponent();
            this._context = _context;
            _currentEmployee = employee;
            StartOptions();
            CheckTrueActivity();
        }
        public void StartOptions()
        {
            nameTeacher.Content = $"Преподаватель {_currentEmployee.fio}";
            code.Content = _currentEmployee.codeEmployee;
            date.Content = _currentEmployee.dateStartWork;
            salary.Content = _currentEmployee.salary;
            phone.Content = _currentEmployee.numberPhone;
            var listStudentForTeacher = _context.StudentOfWell.Where(x => x.Well.Employee.codeEmployee == _currentEmployee.codeEmployee);
            countStudent.Content = listStudentForTeacher.Count().ToString();
            finalSalary.Content = (listStudentForTeacher.Count() * 100 + _currentEmployee.salary).ToString();
        }
        public void CheckTrueActivity()
        {
            var listWell = _context.Well.ToList().FindAll(x=> x.codeEmployee == _currentEmployee.codeEmployee).ToList();
            List<SubjectOfWell> allThemes = new List<SubjectOfWell>();
            foreach (var item in listWell)
            {
                allThemes.AddRange(item.SubjectOfWell);
            }

            DateTime dateTime = DateTime.Now;
            var lll = _context.Activity.Where(x => x.SubjectOfWell.Well.Employee.codeEmployee == _currentEmployee.codeEmployee).ToList();
            var finalList = lll.Where(x => x.data < dateTime).Select(y=> new { CheckActivity = y.data, CheckSubject = y.SubjectOfWell.title });
            //var finalList = lll.Select(x => new { CheckActivity = x.data, CheckSubject = x.SubjectOfWell.title }).ToList();
            checkActivity.ItemsSource = finalList;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
