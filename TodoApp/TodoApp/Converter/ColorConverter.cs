using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TodoApp.Model;
using TodoApp.EF.Context;

namespace TodoApp.Converter
{
    class ColorConverter : IValueConverter
    {
        ApplicationContext db = new();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int categoryId = (int)value;

            // Получаем категорию по идентификатору из базы данных
            Category category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if (category != null)
            {
                return category.Color;
            }

            // Возвращаем значение по умолчанию, если категория не найдена
            return "#fff"; // Замените на свое значение по умолчанию
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
