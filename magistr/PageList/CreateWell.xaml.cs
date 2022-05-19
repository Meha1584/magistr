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
    /// Логика взаимодействия для CreateWell.xaml
    /// </summary>
    public partial class CreateWell : Page
    {
        Employee employee;
        TutoringCenterEntities _context;
        MenuWindow menuWindow;
        public CreateWell(TutoringCenterEntities _context, Employee employee, MenuWindow menuWindow)
        {
            InitializeComponent();
            this.employee = employee;
            this._context = _context;
            this.menuWindow = menuWindow;
            menuWindow.WindowState = WindowState.Maximized;
            dataStudent.ItemsSource = _context.Student.ToList().Where(x=> x.fioStudent != null).ToList();
        }

        Well well = new Well();

        private void CreateWellButton(object sender, RoutedEventArgs e)
        {
            well.codeEmployee = employee.codeEmployee;
            well.title = nameWell.Text;
            try
            {
                _context.Well.Add(well);
                checkCreateSubjectBox.Visibility = Visibility.Visible;
                _context.SaveChanges();

            }
            catch (Exception)
            {
                MessageBox.Show("Введите правильное название курса");
            }
            
        }
        List<Button> listBtn = new List<Button>();
        List<TextBox> listTextbox = new List<TextBox>();
        int countSubjects;
        
        private void CreateSubject(object sender, RoutedEventArgs e)
        {
            try
            {
                countSubjects = Convert.ToInt32(creatCountSubject.Text);
                for (int i = 1; i <= countSubjects; i++)
                {
                    Thickness thickness = new Thickness(10);
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Margin = thickness;
                    
                    Label label = new Label();
                    label.Content = $"Введите название темы {i}";
                    TextBox textBox = new TextBox();
                    listTextbox.Add(textBox);
                    Button btn = new Button();
                    btn.Click += Btn_Click;
                    btn.Content = "Добавить тему";
                    listBtn.Add(btn);
                    stackPanel.Children.Add(label);
                    stackPanel.Children.Add(textBox);
                    stackPanel.Children.Add(btn);
                    createSubjectBox.Children.Add(stackPanel);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите число");
            }
        }
        SubjectOfWell subjectOfWell = new SubjectOfWell();
        int count = 0;
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = sender as Button;
                int i = listBtn.IndexOf(button);
                TextBox textBox = listTextbox[i];
                string str = textBox.Text.Replace(" ", "");
                if (!str.Equals(""))
                {
                    subjectOfWell.idWell = well.idWell;
                    subjectOfWell.title = textBox.Text;
                    _context.SubjectOfWell.Add(subjectOfWell);
                    _context.SaveChanges();
                    count++;
                    button.IsEnabled = false;
                    MessageBox.Show("Тема добавлена");
                    if (count == countSubjects)
                    {
                        checkActivityBox.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    MessageBox.Show("Введите название темы");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите название всем темам");
            }
        }

        List<List<string>> listFirstPartActivity = new List<List<string>>();
        List<Button> buttonActivity = new List<Button>();
        List<ComboBox> comboBoxActivity = new List<ComboBox>();
        List<TextBox> textBoxes = new List<TextBox>();
        private void CreateCountActivityButton(object sender, RoutedEventArgs e)
        {
            
            var subjects = _context.SubjectOfWell.Where(x => x.idWell == well.idWell).Select(x => new { title = x.title }).ToList();
            List<string> listSubjectsForCombobox = new List<string>();
            foreach (var item in subjects)
            {
                listSubjectsForCombobox.Add(item.title);
            }
            try
            {
                int countActivityNum = Convert.ToInt32(createCountActivity.Text);
                for (int i = 1; i <= countActivityNum; i++)
                {
                    StackPanel bigStackPane = new StackPanel();

                    StackPanel moreStackPanel = new StackPanel();
                    moreStackPanel.Orientation = Orientation.Horizontal;
                    moreStackPanel.Width = 300;

                    StackPanel stackPanel = new StackPanel();
                    Label label = new Label();
                    label.Content = $"Занятие {i}";

                    Thickness thickness1 = new Thickness(0, 0, 0, 5);
                    stackPanel.Children.Add(label);
                    moreStackPanel.Children.Add(stackPanel);

                    Thickness thickness = new Thickness(10, 0, 0, 0);

                    StackPanel stackPanel1 = new StackPanel();
                    stackPanel1.Margin = thickness;


                    ComboBox comboBoxListSubject = new ComboBox();
                    comboBoxListSubject.ItemsSource = listSubjectsForCombobox;
                    comboBoxListSubject.SelectedItem = listSubjectsForCombobox[0];
                    comboBoxListSubject.Margin = thickness1;
                    comboBoxListSubject.Width = 150;
                    comboBoxActivity.Add(comboBoxListSubject);
                    stackPanel1.Children.Add(comboBoxListSubject);
                    moreStackPanel.Children.Add(stackPanel1);


                    TextBox textBox1 = new TextBox();
                    textBox1.TextWrapping = TextWrapping.Wrap;
                    textBox1.AcceptsReturn = true;
                    textBox1.Height = 50;
                    textBox1.Margin = thickness1;
                    textBoxes.Add(textBox1);
                    bigStackPane.Children.Add(moreStackPanel);
                    bigStackPane.Children.Add(textBox1);

                    Thickness thickness2 = new Thickness(0,0,0,10);
                    Button button = new Button();
                    button.Content = "Ввести";
                    button.Click += Button_Click;
                    button.Width += 100;
                    button.Margin = thickness2;
                    buttonActivity.Add(button);
                    bigStackPane.Children.Add(button);
                    createActivity.Children.Add(bigStackPane);
                    
                }
            }
            catch
            {
                MessageBox.Show("Введите число");
            }
        }
        int checkPress = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkPress++;
            Button button = sender as Button;
            int check = buttonActivity.IndexOf(button);
            string descriprion = textBoxes[check].Text;
            string subjectOfComboBox = comboBoxActivity[check].Text;
            int checkSubject = _context.SubjectOfWell.Where(x => x.idWell == well.idWell && x.title.Equals(subjectOfComboBox)).ToList().Last().idSubject;

            List<string> moreList = new List<string>();
            moreList.Add(descriprion);
            moreList.Add(checkSubject.ToString());
            listFirstPartActivity.Add(moreList);
            MessageBox.Show("Занятие добавлено");
            button.IsEnabled = false;
            if (checkPress == buttonActivity.Count)
            {
                checkCreateBox.Visibility = Visibility.Visible;
                dayOfWeekBox.Visibility = Visibility.Visible;
            }
        }

        private void CreateFinalyWellButton(object sender, RoutedEventArgs e)
        {
            
            var listStudentOfAcivity = _context.StudentOfWell.Where(x => x.idWell == well.idWell).ToList();
            var listActivity = _context.Activity.Where(x => x.SubjectOfWell.Well.idWell == well.idWell).ToList();
            foreach (var item in listActivity)
            {
                foreach (var item2 in listStudentOfAcivity)
                {
                    StudentActivity studentActivity = new StudentActivity();
                    studentActivity.idActivity = item.idActivty;
                    studentActivity.idStudent = item2.idStudent;
                    _context.StudentActivity.Add(studentActivity);
                    _context.SaveChanges();
                }
            }
            NavigationService.Navigate(new CheckInfoForTeacherPage(employee, _context, menuWindow));
        }

        List<int> checkNumberDay = new List<int>();
        List<string> checkDayList = new List<string>();
        private void AddDay(object sender, RoutedEventArgs e)
        {

            if (sunday.IsChecked == true)
            {
                checkDayList.Add(sunday.Content.ToString());
                checkNumberDay.Add(0);
            }
            if (monday.IsChecked == true)
            {
                checkDayList.Add(monday.Content.ToString());
                checkNumberDay.Add(1);
            }
            if (tuesday.IsChecked == true)
            {
                checkDayList.Add(tuesday.Content.ToString());
                checkNumberDay.Add(2);
            }
            if (wednesay.IsChecked == true)
            {
                checkDayList.Add(wednesay.Content.ToString());
                checkNumberDay.Add(3);
            }
            if (thursday.IsChecked == true)
            {
                checkDayList.Add(thursday.Content.ToString());
                checkNumberDay.Add(4);
            }
            if (friday.IsChecked == true)
            {
                checkDayList.Add(friday.Content.ToString());
                checkNumberDay.Add(5);
            }
            if (saturday.IsChecked == true)
            {
                checkDayList.Add(saturday.Content.ToString());
                checkNumberDay.Add(6);
            }
            checkDayBox.ItemsSource = checkDayList;
            checkDayBox.SelectedItem = checkDayList[0];
            addTimePanel.Visibility = Visibility.Visible;
            enableCheck.IsEnabled = false;
        }

        List<List<string>> listTwoPartActivity = new List<List<string>>();

        int checkPressDay = 0;
        private void AddTime(object sender, RoutedEventArgs e)
        {
            
            //List<string> finalList = new List<string>();
            checkPressDay++;
            string inputTime = timePic.Text;
            string inputTitleDay = checkDayBox.SelectedItem.ToString();
            List<string> list = new List<string>();
            list.Add(inputTime);
            list.Add(inputTitleDay);
            listTwoPartActivity.Add(list);
            if (checkPressDay == checkDayBox.Items.Count)
            {
                press.IsEnabled = false;
                DateTime date = DateTime.Now;
                foreach (var item in listFirstPartActivity)
                {
                    Activity activity = new Activity();
                    activity.idSubject = Convert.ToInt32(item[1]);
                    activity.description = item[0];
                    foreach (var item2 in listTwoPartActivity)
                    {
                        string[] vs = item2[0].Split(':');
                        int hour = Convert.ToInt32(vs[0]);
                        int minutes = Convert.ToInt32(vs[1]);
                        TimeSpan timeSpan = new TimeSpan(hour, minutes, 0);
                        activity.time = timeSpan;
                        bool checkWhile = true;
                        while (checkWhile)
                        {
                            for (int i = 0; i < checkNumberDay.Count; i++)
                            {
                                if (Convert.ToInt32(date.DayOfWeek) == Convert.ToInt32(checkNumberDay[i]))
                                {
                                    activity.data = date;
                                    activity.dayOfWeek = checkDayList[i];
                                    _context.Activity.Add(activity);
                                    _context.SaveChanges();
                                    checkWhile = false;
                                    break;
                                }
                            }
                            date = date.AddDays(1);
                        }
                        break;
                    }
                }
                MessageBox.Show("Все занятия добавлены");
            }
        }

        private void AddStudentOfActivity(object sender, RoutedEventArgs e)
        {
            Student student = dataStudent.SelectedItem as Student;
            StudentOfWell studentOfWell = new StudentOfWell();
            studentOfWell.idStudent = student.idStudent;
            studentOfWell.idWell = well.idWell;
            MessageBox.Show("Студент добавлен");
            _context.StudentOfWell.Add(studentOfWell);
            _context.SaveChanges();
            
        }

        private void ExitPage(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
