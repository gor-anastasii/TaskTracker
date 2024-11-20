using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;
using TodoApp.Infrastructure.Commands;
using TodoApp.ViewModel.Base;
using TodoApp.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System.Windows;
using TodoApp.View;
using TodoApp.ErrorMessageBox;

namespace TodoApp.ViewModel
{
    public class TaskViewModel : Base.ViewModel
    {
        ApplicationContext db = new();

        #region Properties and collections

        private ObservableCollection<Model.Task>? _tasksDT;
        public ObservableCollection<Model.Task>? TasksDT
        {
            get => _tasksDT;
            set => Set(ref _tasksDT, value);
        }

        private ObservableCollection<Model.Task>? _tasksDT2;
        public ObservableCollection<Model.Task>? TasksDT2
        {
            get => _tasksDT2;
            set => Set(ref _tasksDT2, value);
        }

        private ObservableCollection<Category>? _categoriesDT;
        public ObservableCollection<Category>? CategoriesDT
        {
            get => _categoriesDT;
            set => Set(ref _categoriesDT, value);
        }

        private ObservableCollection<PeriodTask>? _periodTasksDT;
        public ObservableCollection<PeriodTask>? PeriodTasksDT
        {
            get => _periodTasksDT;
            set => Set(ref _periodTasksDT, value);
        }
        #endregion

        #region Commands

        private void CreateTaskWin(object o)
        {
            var page = new CreateTask();
            page.Show();
        }

        private void CreateCategoryWin(object o)
        {
            var page = new CreateCategory();
            page.Show();
        }

        private void DeleteCategory(object categoryId)
        {
            try
            {
                var x = MyMessageBox.Show("Do you really want to delete category?", MessageBoxButton.YesNo);
                if (x.Equals(MessageBoxResult.Yes))
                {
                    int id = (int)categoryId;
                    var categoryToDelete = db.Categories.FirstOrDefault(c => c.CategoryId == id);
                    if (categoryToDelete != null)
                    {
                        var tasksToDelete = db.Tasks.Where(t => t.CategoryId == id).ToList();

                        foreach (var task in tasksToDelete)
                        {
                            task.IsDeleted = true;
                            task.DeletedTime = DateTime.Now;
                            db.Update(task);
                            //db.Tasks.Remove(task);
                        }

                        categoryToDelete.DeletedTime = DateTime.Now;
                        categoryToDelete.IsDeleted = true; 
                        db.Update(categoryToDelete);
                        //db.Categories.Remove(categoryToDelete);
                        db.SaveChanges();
                        LoadData();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting category: {ex.Message}");
            }
        }

        private void ChangeIsDone(object id)
        {
            try
            {
                int taskId = (int)id;
                var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);
                if (task != null)
                {
                    task.IsDone = task.IsDone;
                    db.Tasks.Update(task);
                    db.SaveChanges();

                    //UpdateCategoryCounts();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while changing completed: {ex.Message}");
            }
        }

        private void FilterTasks(object categoryid)
        {
            db.Tasks.Load();
            int categoryId = (int)categoryid;
            var filteredTasks = db.Tasks.Local.Where(task => task.CategoryId == categoryId && !task.IsDeleted)
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
            TasksDT = new ObservableCollection<Model.Task>(filteredTasks);
        }

        private async void ResetFilter(object o)
        {
            db.Tasks.Load();
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
            TasksDT = new ObservableCollection<Model.Task>(sortedTasks);
        }
        #endregion
        public async void LoadData()
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
            TasksDT = new ObservableCollection<Model.Task>(sortedTasks);

            UpdateCategoryCounts();
            await db.Categories.LoadAsync();
            var sortedCategories = db.Categories.Local
                                    .Where(category => !category.IsDeleted) 
                                    .OrderByDescending(category => category.CategoryId);
            CategoriesDT = new ObservableCollection<Category>(sortedCategories);

            await db.PeriodTasks.LoadAsync();
            PeriodTasksDT = db.PeriodTasks.Local.ToObservableCollection();
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
                //category.CountOfDone = db.Tasks.Count(task => task.CategoryId == category.CategoryId && task.IsDone && !task.IsDeleted);
            }
            db.SaveChanges();
        }

        public BCommand CreateTaskWinCommand { get; }
        public BCommand CreateCategoryWinCommand { get; }
        public BCommand DeleteCategoryCommand { get; }
        public BCommand ChangeIsDoneCommand { get; }
        public BCommand FilterTasksCommand { get; }
        public BCommand ResetFilterCommand { get; }

        public TaskViewModel()
        {
            LoadData();

            CreateTaskWinCommand = new BCommand(CreateTaskWin, (obj) => true);
            CreateCategoryWinCommand = new BCommand(CreateCategoryWin, (obj) => true);
            DeleteCategoryCommand = new BCommand(DeleteCategory, (o) => true);
            ChangeIsDoneCommand = new BCommand(ChangeIsDone, (o) => true);
            FilterTasksCommand = new BCommand(FilterTasks, (o) => true);
            ResetFilterCommand = new BCommand(ResetFilter, (o) => true);
        }
    }
}
