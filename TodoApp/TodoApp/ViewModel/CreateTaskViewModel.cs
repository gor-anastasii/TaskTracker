using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.View;
using TodoApp.ViewModel.Base;
using TodoApp.Infrastructure.Commands;
using System.Windows;
using TodoApp.ErrorMessageBox;
using TodoApp.EF.Context;
using System.Collections.ObjectModel;
using TodoApp.Global;
using Microsoft.EntityFrameworkCore;
using TodoApp.Model;
using System.Windows.Controls;

namespace TodoApp.ViewModel
{
    public class CreateTaskViewModel : Base.ViewModel
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

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private DateTime? _selectedDeadline;
        public DateTime? SelectedDeadline
        {
            get { return _selectedDeadline; }
            set
            {
                _selectedDeadline = value?.Date;
                OnPropertyChanged("SelectedDeadline");
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        private DateTime? _selectedPeriod;
        public DateTime? SelectedPeriod
        {
            get { return _selectedPeriod; }
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged("SelectedPeriod");
            }
        }

        private string _selectedFreq;
        public string SelectedFreq
        {
            get { return _selectedFreq; }
            set
            {
                _selectedFreq = value;
                OnPropertyChanged("SelectedFreq");
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

        #endregion

        #region Commands
        private void SaveTask(object o)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Title))
                {
                    MyMessageBox.Show("Title cannot be empty.", MessageBoxButton.OK);
                    return;
                }
                if (Title.Length > 28)
                {
                    throw new Exception($"Title exceeds the maximum length of 28 characters. Current length: {Title.Length}");
                }
                Title = Title.Trim();


                if (string.IsNullOrWhiteSpace(Description))
                {
                    MyMessageBox.Show("Description cannot be empty.", MessageBoxButton.OK);
                    return;
                }
                if (Description.Length > 250)
                {
                    throw new Exception($"Title exceeds the maximum length of 250 characters. Current length: {Description.Length}");
                }
                Description = Description.Trim();

                if (SelectedPeriod != null && SelectedFreq != null)
                {
                    // Проверяем, что у нас есть дедлайн для обычной задачи
                    if (SelectedDeadline.HasValue || SelectedDeadline != null)
                    {
                        throw new Exception("For periodic task, deadline is not required.");
                    }
                    AddPeriodTask();
                }
                else
                {
                    // Проверяем, что дедлайн не пустой
                    if (!SelectedDeadline.HasValue || SelectedDeadline == null)
                    {
                        throw new Exception("Deadline is required for non-periodic task.");
                    }
                    // Далее ваш текущий код
                    if (SelectedDeadline.Value.Date < DateTime.Today)
                    {
                        throw new Exception("The deadline must be greater than today's date.");
                    }
                    AddTask();
                }

                db.SaveChanges();

                LoadTask();
                _window.Close();
            } catch (Exception ex)
            {
                MyMessageBox.Show(ex.Message, MessageBoxButton.OK);
            }

            Title = string.Empty;
            Description = string.Empty;
            SelectedDeadline = null;
            SelectedCategory = null;
            SelectedPeriod = null;
        }

        private void AddTask()
        {
            var selectedCategory = db.Categories.FirstOrDefault(c => c.Title == SelectedCategory && !c.IsDeleted);
            DateTime deadline = ((DateTime)SelectedDeadline).Date;

            if (selectedCategory != null)
            {
                Model.Task newTask = new Model.Task()
                {
                    Title = Title,
                    Description = Description,
                    Deadline = deadline,
                    IsDone = false,
                    IsDeleted = false,
                    СreationTime = DateTime.Now,
                    CategoryId = selectedCategory.CategoryId
                };
                db.Tasks.Add(newTask);
            }
            else
            {
                Model.Task newTask = new Model.Task()
                {
                    Title = Title,
                    Description = Description,
                    Deadline = deadline,
                    IsDone = false,
                    IsDeleted = false,
                    СreationTime = DateTime.Now,
                };
                db.Tasks.Add(newTask);
            }
        }

        private void AddPeriodTask()
        {
            var selectedCategory = db.Categories.FirstOrDefault(c => c.Title == SelectedCategory && !c.IsDeleted);

            if (SelectedPeriod != null && SelectedFreq != null)
            {
                if (((DateTime)SelectedPeriod).Date < DateTime.Today)
                {
                    throw new Exception("The end of period must be greater than today's date.");
                }
                else
                {
                    PeriodTask periodTask = new PeriodTask
                    {
                        beginPeriodTask = DateTime.Now,
                        endPeriodTask = (DateTime)SelectedPeriod,
                        Frequency = SelectedFreq.ToString()
                    };


                    int newPeriodId = periodTask.PeriodTaskId;

                    db.PeriodTasks.Add(periodTask);

                    DateTime startPeriod = DateTime.Now;
                    DateTime endPeriod = (DateTime)SelectedPeriod;

                    TimeSpan interval;

                    switch (SelectedFreq)
                    {
                        case "daily":
                            interval = TimeSpan.FromDays(1);
                            break;
                        case "weekly":
                            interval = TimeSpan.FromDays(7);
                            break;
                        case "monthly":
                            interval = TimeSpan.FromDays(30);
                            break;
                        default:
                            throw new Exception("Invalid frequency.");
                    }

                    while (startPeriod <= endPeriod)
                    {
                        if (startPeriod <= endPeriod)
                        {
                            if (selectedCategory != null)
                            {
                                Model.Task periodicTask = new Model.Task()
                                {
                                    Title = Title,
                                    Description = Description,
                                    Deadline = startPeriod,
                                    IsDone = false,
                                    IsDeleted = false,
                                    СreationTime = DateTime.Now,
                                    CategoryId = selectedCategory.CategoryId,
                                    PeriodId = newPeriodId
                                };
                                db.Tasks.Add(periodicTask);
                            }
                            else
                            {
                                Model.Task periodicTask = new Model.Task()
                                {
                                    Title = Title,
                                    Description = Description,
                                    Deadline = startPeriod,
                                    IsDone = false,
                                    IsDeleted = false,
                                    СreationTime = DateTime.Now,
                                    PeriodId = newPeriodId
                                };
                                db.Tasks.Add(periodicTask);
                            }
                        }
                        startPeriod += interval;
                    }
                }
            }
        }

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
            mvm.TasksDT= new ObservableCollection<Model.Task>(sortedTasks);

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

        private void UpdateFreq(object freq)
        {
            SelectedFreq = (string)freq;
        }
        #endregion

        public BCommand SaveTaskCommand { get; }
        public BCommand UpdateFreqCommand { get; }
        public CreateTaskViewModel(Window window)
        {
            _window = window;
            SaveTaskCommand = new BCommand(SaveTask, (o) => true);
            UpdateFreqCommand = new BCommand(UpdateFreq, (o) => true);

            using (var dbContext = new ApplicationContext())
            {
                Categories = new ObservableCollection<string>(dbContext.Categories.Where(c => !c.IsDeleted).Select(c => c.Title));
            }
            
        }
    }
}

