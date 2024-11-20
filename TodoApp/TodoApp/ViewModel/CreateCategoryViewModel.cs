using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TodoApp.EF.Context;
using TodoApp.ErrorMessageBox;
using TodoApp.Infrastructure.Commands;
using TodoApp.Model;
using TodoApp.View;
using TodoApp.Global;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TodoApp.ViewModel
{
    public class CreateCategoryViewModel : Base.ViewModel
    {
        ApplicationContext db = new();
        private System.Windows.Window _window;
        TaskViewModel mvm = Globals.GetMVM();

        #region Properties and collections

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        #endregion

        #region Commands

        private void SaveCategory(object o)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    MyMessageBox.Show("Title cannot be empty.", MessageBoxButton.OK);
                    return;
                }
                if (Title.Length > 16)
                {
                    throw new Exception($"Title exceeds the maximum length of 16 characters. Current length: {Title.Length}");
                }
                Title = Title.Trim();

                if (Color == null)
                {
                    throw new Exception("Please choose a color");
                }

                Category category = new Category()
                {
                    Title = Title,
                    Color = Color,
                    CountOfDone = 0,
                    CountOfTasks = 0,
                    СreationTime = DateTime.Now,
                    IsDeleted = false
                };
                db.Categories.Add(category);
                db.SaveChanges();

                Title = string.Empty;
                Color = string.Empty;

                LoadCategory();
                _window.Close();
            } catch (Exception ex)
            {
                MyMessageBox.Show(ex.Message, MessageBoxButton.OK);
            }
           
        }

        private void SelectColor(object color)
        {
            Color = color.ToString();
        }   

        private async void LoadCategory()
        {
            await db.Tasks.LoadAsync();
            var sortedTasks = db.Tasks.Local
                          .Where(task => !task.IsDeleted)
                          .GroupBy(task => task.PeriodId)
                          .SelectMany(group =>
                          {
                              if (group.Key != null)
                              {
                                  return group.Where(task => task.Deadline.Date == DateTime.Today);
                              }
                              else
                              {
                                  return group;
                              }
                          })
                          .OrderBy(task => task.IsDone)
                          .ThenBy(task => task.Deadline);
            mvm.TasksDT = new ObservableCollection<Model.Task>(sortedTasks);

            UpdateCategoryCounts();
            await db.Categories.LoadAsync();
            var sortedCategories = db.Categories.Local.Where(category => !category.IsDeleted).OrderByDescending(category => category.CategoryId);
            mvm.CategoriesDT = new ObservableCollection<Category>(sortedCategories);
        }

        private void UpdateCategoryCounts()
        {
            foreach (var category in db.Categories)
            {
                int regularTasksCount = db.Tasks.Count(task => task.CategoryId == category.CategoryId && !task.IsDeleted && !task.PeriodId.HasValue);
                int periodicTasksCount = db.Tasks.Count(task => task.CategoryId == category.CategoryId && task.PeriodId.HasValue && task.Deadline.Date == DateTime.Today && !task.IsDeleted);

                int regularTasksCountDone = db.Tasks.Count(task => task.CategoryId == category.CategoryId && !task.IsDeleted && !task.PeriodId.HasValue && task.IsDone);
                int periodicTasksCountDone = db.Tasks.Count(task => task.CategoryId == category.CategoryId && task.PeriodId.HasValue && task.Deadline.Date == DateTime.Today && !task.IsDeleted && task.IsDone);


                category.CountOfTasks = regularTasksCount + periodicTasksCount;
                category.CountOfDone = regularTasksCountDone + periodicTasksCountDone;
            }
            db.SaveChanges();
        }
        #endregion

        public BCommand SaveCategoryCommand { get; }
        public BCommand SelectColorCommand { get; }
       

        public CreateCategoryViewModel(System.Windows.Window window)
        {
            _window = window;
            SelectColorCommand = new BCommand(SelectColor, (o) => true);
            SaveCategoryCommand = new BCommand(SaveCategory, (o) => true);
            
        }

    }
}
