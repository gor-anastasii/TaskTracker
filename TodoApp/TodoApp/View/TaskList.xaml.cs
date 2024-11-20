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
using TodoApp.ViewModel;
using TodoApp.Global;

namespace TodoApp.View
{
    /// <summary>
    /// Логика взаимодействия для TaskList.xaml
    /// </summary>
    public partial class TaskList : Page
    {
        public TaskList()
        {
            InitializeComponent();
            DataContext = Globals.GetMVM();
        }

        private void OpenEditTaskWindow_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var task = (Model.Task)button.DataContext;

            EditTask editTaskWindow = new EditTask(task);
            editTaskWindow.Show();
        }

       
    }
}
