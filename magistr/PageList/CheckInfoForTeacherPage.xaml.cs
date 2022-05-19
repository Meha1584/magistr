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
    /// Логика взаимодействия для CheckInfoForTeacherPage.xaml
    /// </summary>
    public partial class CheckInfoForTeacherPage : Page
    {
        Employee employee;
        TutoringCenterEntities _context;
        MenuWindow menuWindow;
        public CheckInfoForTeacherPage(Employee employee, TutoringCenterEntities _context, MenuWindow menuWindow)
        {
            InitializeComponent();
            this.employee = employee;
            this._context = _context;
            this.menuWindow = menuWindow;
            menuWindow.Width = 900;
            menuWindow.Height = 600;
            OutputWell();
            nameTeacher.Content = $"Здравствуйте, {employee.fio}";
            CheckTeacher();
        }

        List<string> stringList;
        List<CheckStudent> checkStudents = new List<CheckStudent>();
        List<CheckStudent> tempCheckStudents = new List<CheckStudent>();
        List<string> listWell = new List<string>();
        public void CheckTeacher()
        {
            var listStudentOfWell = _context.StudentOfWell.Where(x => x.Well.Employee.codeEmployee == employee.codeEmployee).ToList();

            var tempListStudent = listStudentOfWell.Join(_context.Well,
                x => x.idWell,
                y => y.idWell,
                (x, y) => new
                {
                    idWell = x.idWell,
                    idStudent = x.idStudent,
                    Title = y.title
                }).ToList();
            var tempListStudent2 = tempListStudent.Join(_context.Student,
                x => x.idStudent,
                y => y.idStudent,
                (x, y) => new
                {
                    idWell = x.idWell,
                    id = x.idStudent,
                    FioStudent = y.fioStudent,
                    FullNameOfTheParent = y.fullNameOfTheParent,
                    NumberPhone = y.phone,
                    Title = x.Title
                }).ToList();

            checkStudents = tempListStudent2.Join(_context.StudentActivity,
                x => x.id,
                y => y.idStudent,
                (x, y) => new CheckStudent()
                {
                    idWell = x.idWell,
                    IdStudent = x.id,
                    idActivity = y.idActivity,
                    FioStudent = x.FioStudent,
                    FullNameOfTheParent = x.FullNameOfTheParent,
                    NumberPhone = (double)x.NumberPhone,
                    Attendance = y.attendance==null?"": y.attendance,
                    ReasonforAbsence = y.reasonforAbsence == null ? "" : y.reasonforAbsence,
                    PercentageOfEarnedMaterial = (double?)y.PercentageOfEarnedMaterial,
                    Title = x.Title,
                    Activity = y.Activity.data.ToShortDateString(),
                    Description = y.Activity.description
                }).ToList();

            tempCheckStudents = checkStudents.Where(z => z.Activity.Equals(stringList[0])).Where(y => y.Title.Equals(filterWell.SelectedItem)).ToList();
            dataStudent.ItemsSource = tempCheckStudents;
        }

        //public void OutputDate()
        //{
        //    //var listDate = _context.StudentActivity.Where(x => );
            
        //    listDate.AddRange(_context.Activity.Where(x=> x.SubjectOfWell.Well.Employee.codeEmployee == employee.codeEmployee).Select(z => new DateActivityOfStudent{ DateP = z.data }));
           
        //    foreach (var item in listDate)
        //    {
        //        stringList.Add(item.Date);
        //    }
        //    checkDate.ItemsSource = stringList;
        //    checkDate.SelectedItem = stringList[0];
        //}
        public void OutputWell()
        {
            //OutputDate();
            var listOfWell = _context.Well.Where(x=> x.codeEmployee == employee.codeEmployee);
            foreach (var item in listOfWell)
            {
                listWell.Add(item.title);
            }
            filterWell.ItemsSource = listWell.ToList();
            filterWell.SelectedItem = listWell.Last();
            dataWell.ItemsSource = listOfWell.ToList().Where(x=> x.title != null);
        }

        private void CheckItem(object sender, SelectionChangedEventArgs e)
        {
            tempCheckStudents = checkStudents.Where(x => x.Activity.Equals(checkDate.SelectedItem)).Where(y=> y.Title.Equals(filterWell.SelectedItem)).ToList();
            foreach (var item in tempCheckStudents)
            {
                descriptionActivity.Text = item.Description;
            }
            dataStudent.ItemsSource = tempCheckStudents;
            dataStudent.Items.Refresh();
        }

        private void FindStudent(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(findTeacher.Text))
            {
                tempCheckStudents = checkStudents.Where(x => x.Activity.Equals(checkDate.SelectedItem)).Where(y => y.Title.Equals(filterWell.SelectedItem)).Where(x => x.FioStudent.Contains(findTeacher.Text)).ToList();
                dataStudent.ItemsSource = tempCheckStudents;
                dataStudent.Items.Refresh();
            }
            else
            {
                tempCheckStudents = checkStudents.Where(x => x.Activity.Equals(checkDate.SelectedItem)).Where(y => y.Title.Equals(filterWell.SelectedItem)).ToList();
                dataStudent.ItemsSource = tempCheckStudents;
                dataStudent.Items.Refresh();
            }
        }

        private void SaveEdit(object sender, RoutedEventArgs e)
        {
            int count = 0;
            foreach (var item in tempCheckStudents)
            {
                CheckStudent student = dataStudent.Items[count] as CheckStudent;

                StudentActivity studentActivity = _context.StudentActivity.Where(x => x.idActivity == student.idActivity && x.idStudent == student.IdStudent).FirstOrDefault();
                if (studentActivity != null)
                {
                    studentActivity.idActivity = studentActivity.idActivity;
                    studentActivity.idStudent = studentActivity.idStudent;
                    studentActivity.PercentageOfEarnedMaterial = (decimal?)student.PercentageOfEarnedMaterial ?? 0;
                    studentActivity.reasonforAbsence = student.ReasonforAbsence ?? "";
                    studentActivity.attendance = student.Attendance ?? "";
                    _context.Entry(studentActivity).State = System.Data.Entity.EntityState.Modified;
                }
                _context.SaveChanges();
                count++;
            }
        }

        private void CheckWell(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CheckTimeTable(employee));
        }

        private void FilterWell(object sender, SelectionChangedEventArgs e)
        {
            List<DateActivityOfStudent> listDate = new List<DateActivityOfStudent>();
            var l = _context.Activity.Where(x => x.SubjectOfWell.Well.Employee.codeEmployee == employee.codeEmployee).ToList();
            var i = l.Where(y => y.SubjectOfWell.Well.title.Equals(filterWell.SelectedItem)).ToList();
            var final = i.Select(z => new DateActivityOfStudent { DateP = z.data }).ToList();
            listDate.AddRange(final);
            stringList = new List<string>();
            foreach (var item in listDate)
            {
                stringList.Add(item.Date);
            }
            if (stringList.Count > 0)
            {
                checkDate.ItemsSource = stringList;
                checkDate.SelectedItem = stringList[0];
                tempCheckStudents = checkStudents.Where(x => x.Title.Equals(filterWell.SelectedItem)).Where(x => x.Activity.Equals(checkDate.SelectedItem)).ToList();

                dataStudent.ItemsSource = tempCheckStudents;
                dataStudent.Items.Refresh();
            }
            else
            {
                MessageBox.Show("В этом курсе нет занятий");
            }
        }

        private void CreateWell(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateWell(_context, employee, menuWindow));
        }

        private void FilterTextString(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(findWell.Text))
            {
                var listWellFinal = listWell.Where(x => x.Contains(findWell.Text)).ToList();
                dataWell.ItemsSource = listWellFinal;
                dataWell.Items.Refresh();
            }
            else
            {
                dataWell.ItemsSource = listWell;
                dataWell.Items.Refresh();
            }
        }

        private void CreateReport(object sender, RoutedEventArgs e)
        {

        }
    }
}
