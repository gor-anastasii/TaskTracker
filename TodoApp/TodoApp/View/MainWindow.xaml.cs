using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoApp.ErrorMessageBox;
using TodoApp.View;
using TodoApp.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db = new();
        private bool isNotificationWindowOpen = false;
        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new Dashbord();
            DashbordPage.IsEnabled = false;

            db.Tasks.Load();
            var sortedTasks = db.Tasks.Local.Where(task => !task.IsDeleted && !task.IsDone && task.Deadline.Date < DateTime.Today && !task.PeriodId.HasValue).Count();
            if(sortedTasks > 0)
            {
                Color color = (Color)ColorConverter.ConvertFromString("#FF6464");
                NotifyEll.Fill = new SolidColorBrush(color);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }

        private void Support_PreviewMouseDown(object sender, RoutedEventArgs e)
        {
            MyMessageBox.Show("Created by Anastasia Gorodilina\n2024, Minsk", MessageBoxButton.OK);
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var x = MyMessageBox.Show("Do you really want to leave?", MessageBoxButton.YesNo);
            if (x.Equals(MessageBoxResult.Yes))
            {
                MainWindow.GetWindow(this).Close();
            }
            else if (x.Equals(MessageBoxResult.No))
            {
                e.Handled = true;
            }
        }

        private void Notify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isNotificationWindowOpen)
            {
                db.Tasks.Load();
                var sortedTasks = db.Tasks.Local.Where(task => !task.IsDeleted && !task.IsDone && task.Deadline.Date < DateTime.Today && !task.PeriodId.HasValue).Count();

                if (sortedTasks > 0)
                {
                    NotifyWindow notifyWindow = new NotifyWindow();

                    Popup popup = new Popup();
                    popup.Child = notifyWindow;

                    popup.Width = 300;
                    popup.Height = 200;

                    popup.HorizontalOffset = 1250;
                    popup.VerticalOffset = 80;

                    popup.IsOpen = true;
                    isNotificationWindowOpen = true;

                    popup.MouseLeave += (s, ev) =>
                    {
                        popup.IsOpen = false;
                        Color color = Color.FromArgb(0, 0, 0, 0);
                        NotifyEll.Fill = new SolidColorBrush(color);
                    };
                }
            }
        }

        private void TasksPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new TaskList();
            TasksPage.IsEnabled = false;
            DashbordPage.IsEnabled = true;
            AnalyticPage.IsEnabled = true;
        }

        private void DashbordPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new Dashbord();
            TasksPage.IsEnabled = true;
            DashbordPage.IsEnabled = false;
            AnalyticPage.IsEnabled = true;
        }

        private void AnalyticPage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Content = new Analytic();
            TasksPage.IsEnabled = true;
            DashbordPage.IsEnabled = true;
            AnalyticPage.IsEnabled = false;
        }
    }
}