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
using TodoApp.ViewModel;

namespace TodoApp.View
{
    /// <summary>
    /// Логика взаимодействия для CreateCategory.xaml
    /// </summary>
    public partial class CreateCategory : Window
    {
        public CreateCategory()
        {
            CreateCategoryViewModel viewmodel = new CreateCategoryViewModel(this);
            InitializeComponent();
            DataContext = viewmodel;
        }

        private void Exit_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private Button previousButton;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = (Button)sender;

            var ellipse = currentButton.Template.FindName("Ellipse", currentButton) as Ellipse;
            ellipse.StrokeThickness = 4;

            if (previousButton != null && previousButton != currentButton)
            {
                var previousEllipse = previousButton.Template.FindName("Ellipse", previousButton) as Ellipse;
                previousEllipse.StrokeThickness = 2;
            }

            previousButton = currentButton;
        }
    }
}
