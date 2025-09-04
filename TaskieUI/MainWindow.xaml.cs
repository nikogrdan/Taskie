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
using Taskie;
using Taskie.Data;
using TaskieCore;

namespace TaskieUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ITaskDao taskDao = new TaskRepository();
        public MainWindow()
        {
            InitializeComponent();
            TasksList.ItemsSource = taskDao.GetAllTasks();
        }
        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            string title = TitleInput.Text;
            int importance = (int)ImportanceInput.Value;
            DateTime time = DateInput.SelectedDate ?? DateTime.Now;
            ToDoTask t = new DeadlineTask(title, importance, time);
            taskDao.SaveTask(t);
            TasksList.Items.Refresh();
        }
        private void TasksList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var taskToRemove = TasksList.SelectedItem as ToDoTask;
            taskDao.Delete(taskToRemove);
            TasksList.Items.Refresh();
        }
        private void ShowImportantTasks(object sender, RoutedEventArgs e)
        {
            int count = 0;
            List<ToDoTask> tasks = new List<ToDoTask>();
            DateTime today = DateTime.Now.Date;
            tasks = taskDao.GetAllTasks().ToList();
            foreach (var task in tasks)
            {
                if (task.GetImportance() == 3)
                {
                    count++;
                }
            }
            MessageBoxResult result = MessageBox.Show($"Number of priority tasks is: {count}");
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            string name = TaskToCompleteInput.Text;
            taskDao.DeleteAll(name);
            TasksList.Items.Refresh();
        }
    }
}