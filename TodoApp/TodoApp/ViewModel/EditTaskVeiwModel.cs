using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;
using TodoApp.EF.Context;
using TodoApp.Infrastructure.Commands;
using System.Windows;
using TodoApp.Global;
using TodoApp.EF.Context;
using Microsoft.EntityFrameworkCore;
using TodoApp.ErrorMessageBox;
using LiveCharts;

namespace TodoApp.ViewModel
{
    public class EditTaskVeiwModel : Base.ViewModel
    {
        ApplicationContext db = new();
        private System.Windows.Window _window;
        TaskViewModel mvm = Globals.GetMVM();


        #region Properties and collections

        private Model.Task _task;
        public Model.Task Task
        {
            get { return _task; }
            set
            {
                _task = value;
                OnPropertyChanged(nameof(Task));
            }
        }

        private ObservableCollection<string> _categories;
        public ObservableCollection<string> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged("Categories");
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private string _taskTitle;
        public string TaskTitle
        {
            get { return _taskTitle; }
            set
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }

        private string _taskDesc;
        public string TaskDesc
        {
            get { return _taskDesc; }
            set
            {
                _taskDesc = value;
                OnPropertyChanged(nameof(TaskDesc));
            }
        }

        private DateTime _taskDeadline;
        public DateTime TaskDeadline
        {
            get { return _taskDeadline; }
            set
            {
                _taskDeadline = value;
                OnPropertyChanged(nameof(TaskDeadline));
            }
        }


        #endregion

        #region Commands

        private void SaveEdit(object o)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TaskTitle))
                {
                    throw new Exception("Title cannot be empty.");
                } else 
                if (TaskTitle.Length > 28)
                {
                    throw new Exception($"Title exceeds the maximum length of 28 characters. Current length: {TaskTitle.Length}");
                } else
                if (string.IsNullOrWhiteSpace(TaskDesc))
                {
                    throw new Exception("Description cannot be empty.");
                }
                else if (TaskDesc.Length > 250)
                {
                    throw new Exception($"Description exceeds the maximum length of 250 characters. Current length: {TaskDesc.Length}");
                }else 
                if (TaskDeadline < DateTime.Today)
                {
                    throw new Exception("The deadline must be greater than today's date.");
                }
                else
                {
                    using (var dbContext = new ApplicationContext())
                    {
                        TaskTitle = TaskTitle.Trim();
                        TaskDesc = TaskDesc.Trim();
                        var selectedCategory = dbContext.Categories.FirstOrDefault(c => c.Title == SelectedCategory);
                        if (selectedCategory != null)
                        {
                            Task.CategoryId = selectedCategory.CategoryId;
                        }
                        Task.Title = TaskTitle;
                        Task.Deadline = TaskDeadline;
                        Task.Description = TaskDesc;
                        dbContext.Tasks.Update(Task);
                        dbContext.SaveChanges();
                        _window.Close();
                    }
                
                }
                LoadTask();
            }
            catch (Exception ex)
            {
                MyMessageBox.Show(ex.Message, MessageBoxButton.OK);
            }
        }

        private void DeleteTask(object o)
        {
            try
            {
                var x = MyMessageBox.Show("Do you really want to delete task?", MessageBoxButton.YesNo);
                if (x.Equals(MessageBoxResult.Yes))
                {
                    using (var dbContext = new ApplicationContext())
                    {
                        var taskToDelete = dbContext.Tasks.FirstOrDefault(t => t.Id == Task.Id);
                        if (taskToDelete != null)
                        {
                            var timersToDelete = dbContext.Timers.Where(t => t.TaskId == taskToDelete.Id).ToList();
                            dbContext.Timers.RemoveRange(timersToDelete);

                            taskToDelete.IsDeleted = true;
                            taskToDelete.DeletedTime = DateTime.Now;
                            dbContext.Tasks.Update(taskToDelete);
                            dbContext.SaveChanges();
                            //dbContext.Tasks.Remove(taskToDelete);
                            //dbContext.SaveChanges();
                        }
                    }

                    LoadTask();
                    _window.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public BCommand SaveEditCommand { get; }
        public BCommand DeleteTaskCommand { get; }

        private async void LoadTask()
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
            var sortedCategories = db.Categories.Local
                .Where(category => !category.IsDeleted)
                .OrderByDescending(category => category.CategoryId);
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

        public EditTaskVeiwModel(Model.Task task, System.Windows.Window window)
        {
            _window = window;
            SaveEditCommand = new BCommand(SaveEdit, (o) => true);
            DeleteTaskCommand = new BCommand(DeleteTask, (o) => true);

            Task = task;
            TaskTitle = Task.Title;
            TaskDesc = Task.Description;
            TaskDeadline = Task.Deadline;
            
            var selectedCategory = db.Categories.FirstOrDefault(c => c.CategoryId == Task.CategoryId);
            if (selectedCategory != null)
            {
                SelectedCategory = selectedCategory.Title;
            }
            else
            {
                SelectedCategory = string.Empty;
            }
            using (var dbContext = new ApplicationContext())
            {
                Categories = new ObservableCollection<string>(dbContext.Categories.Where(c => !c.IsDeleted).Select(c => c.Title));
            }
        }
    }
}
