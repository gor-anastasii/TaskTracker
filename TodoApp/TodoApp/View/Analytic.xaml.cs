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
    /// Логика взаимодействия для Analytic.xaml
    /// </summary>
    public partial class Analytic : Page
    {
        public Analytic()
        {
            AnalyticViewModel viewmodel = new AnalyticViewModel();
            InitializeComponent();
            DataContext = viewmodel;
        }
    }
}
