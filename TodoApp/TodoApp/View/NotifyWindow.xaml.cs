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

namespace TodoApp.View
{
    /// <summary>
    /// Логика взаимодействия для NotifyWindow.xaml
    /// </summary>
    public partial class NotifyWindow : UserControl
    {
        public NotifyWindow()
        {
            NotifyViewModel viewModel = new NotifyViewModel();
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
