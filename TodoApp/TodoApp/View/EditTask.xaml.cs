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
using TodoApp.Model;
using TodoApp.ViewModel;
using TodoApp.ViewModel.Base;

namespace TodoApp.View
{
    /// <summary>
    /// Логика взаимодействия для EditTask.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        public EditTask(Model.Task task)
        {
            InitializeComponent();
            EditTaskVeiwModel viewModel = new EditTaskVeiwModel(task, this);
            DataContext = viewModel;
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
