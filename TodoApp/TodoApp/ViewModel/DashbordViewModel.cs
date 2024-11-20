using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;
using TodoApp.EF.Context;
using Microsoft.EntityFrameworkCore;
using TodoApp.Infrastructure.Commands;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using TodoApp.ErrorMessageBox;
using System.Windows;

namespace TodoApp.ViewModel
{
    class DashbordViewModel : Base.ViewModel
    {
        ApplicationContext db = new();
        private DispatcherTimer _dispatcherTimer;
        private bool _isTimerRunning;
        private string timerTime;

        #region Properties and collections

        private ObservableCollection<Model.Task>? _tasksDT;
        public ObservableCollection<Model.Task>? TasksDT
        {
            get => _tasksDT;
            set => Set(ref _tasksDT, value);
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

        private ObservableCollection<string>? _tasksTitle;
        public ObservableCollection<string>? TasksTitle
        {
            get => _tasksTitle;
            set => Set(ref _tasksTitle, value);
        }

        private Model.Timer? _currentTimer;
        public Model.Timer? CurrentTimer
        {
            get => _currentTimer;
            set => Set(ref _currentTimer, value);
        }

        private TimeSpan _selectedTime;
        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set => Set(ref _selectedTime, value);
        }

        private SeriesCollection _seriesCollection;
        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set => Set(ref _seriesCollection, value);
        }

        //private string _toggleIcon;
        //public string ToggleIcon
        //{
        //    get => _toggleIcon;
        //    set => Set(ref _toggleIcon, value);
        //}

        private bool _isButtonEnabled = true;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        private bool _isRadioEnabled = true;
        public bool IsRadioEnabled
        {
            get { return _isRadioEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsRadioEnabled));
            }
        }

        private string _selectedTask;
        public string SelectedTask
        {
            get => _selectedTask;
            set => Set(ref _selectedTask, value);
        }

        #endregion

        #region Command

        private void UpdateTimer(object selectedTimer)
        {
            if (selectedTimer is string timeString)
            {
                timerTime = timeString;
                if (TimeSpan.TryParse(timeString, out TimeSpan time))
                {
                    SelectedTime = time;

                }
            }
            //if (selectedTimer is string timeString)
            //{
            //    if (TimeSpan.TryParse(timeString, out TimeSpan time))
            //    {
            //        SelectedTime = time;


            //        if (!string.IsNullOrEmpty(SelectedTask))
            //        {
            //            Model.Task selectedTask = db.Tasks.FirstOrDefault(t => t.Title == SelectedTask);
            //            if (selectedTask != null)
            //            {
            //                CurrentTimer = new Model.Timer
            //                {
            //                    Duration = time,
            //                    CurrentTime = time,
            //                    TaskId = selectedTask.Id
            //                };

            //                db.Timers.Add(CurrentTimer);
            //                db.SaveChanges();
            //            }
            //        }
            //    }
            //}
        }

        private void CreateTimer(object e)
        {
            if (!string.IsNullOrEmpty(SelectedTask) && TimeSpan.TryParse(timerTime, out TimeSpan time))
            {
                Model.Task selectedTask = db.Tasks.FirstOrDefault(t => t.Title == SelectedTask);
                if (selectedTask != null)
                {
                    CurrentTimer = new Model.Timer
                    {
                        Duration = time,
                        CurrentTime = time,
                        TaskId = selectedTask.Id
                    };

                    db.Timers.Add(CurrentTimer);
                    db.SaveChanges();

                    SelectedTime = time;
                    _isTimerRunning = true;
                    IsButtonEnabled = false;
                    _dispatcherTimer.Start();
                }

                IsRadioEnabled = false;
            }
        }

        private void PauseButtonClicked(object o)
        {
            if (!string.IsNullOrEmpty(SelectedTask))
            {
                _isTimerRunning = !_isTimerRunning;

                if (SelectedTime != TimeSpan.Zero)
                {
                    if (_isTimerRunning)
                    {
                        _dispatcherTimer.Start();
                    }
                    else
                    {
                        _dispatcherTimer.Stop();
                    }

                    using (var dbContext = new ApplicationContext())
                    {
                        if (CurrentTimer != null)
                        {
                            CurrentTimer.CurrentTime = SelectedTime;
                            dbContext.Timers.Update(CurrentTimer);
                            dbContext.SaveChanges();
                        }
                    }
                }
            }
        }

        private void RunTimer()
        {
            using (var dbContext = new ApplicationContext())
            {
                while (true)
                {
                    if (_isTimerRunning)
                    {
                        if (SelectedTime.TotalSeconds > 0)
                        {
                            SelectedTime = SelectedTime.Subtract(TimeSpan.FromSeconds(1));
                            IsButtonEnabled = false;

                            if (CurrentTimer != null)
                            {
                                CurrentTimer.CurrentTime = SelectedTime;
                                db.Timers.Update(CurrentTimer);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            _isTimerRunning = false;
                            IsButtonEnabled = true;
                            IsRadioEnabled = true;
                            _dispatcherTimer.Stop();
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
        }

        private void ResetTimer(object e)
        {
            if (CurrentTimer != null)
            {
                db.Timers.Remove(CurrentTimer);
                db.SaveChanges();
            }

            CurrentTimer = null;
            //ToggleIcon = "Play";
            _isTimerRunning = false;
            _dispatcherTimer.Stop();
            SelectedTime = TimeSpan.Zero;
            SelectedTask = null;
            IsButtonEnabled = true;
            IsRadioEnabled = true;
        }
        #endregion

        public async void LoadData()
        {
            await db.Tasks.LoadAsync();
            DateTime currentDate = DateTime.Today;
            DateTime tomorrowDate = currentDate.AddDays(1);
            var filteredTasks = db.Tasks.Local
                             .Where(task => !task.IsDone && !task.IsDeleted && (task.Deadline >= currentDate && task.Deadline <= tomorrowDate))
                             .OrderBy(task => task.Deadline)
                             .ToList();

            if (filteredTasks.Count == 0)
            {
                filteredTasks = db.Tasks.Local
                    .Where(task => !task.IsDone && !task.IsDeleted)
                    .OrderBy(task => task.Deadline)
                    .Take(3)
                    .ToList();
            }
            TasksDT = new ObservableCollection<Model.Task>(filteredTasks);

            UpdateCategoryCounts();
            await db.Categories.LoadAsync();
            var sortedCategories = db.Categories.Local
                .Where(category => !category.IsDeleted)
                .OrderByDescending(category => category.CategoryId);
            CategoriesDT = new ObservableCollection<Category>(sortedCategories);

        }

        private void LoadDiagramm()
        {
            var categories = db.Categories.Where(c => !c.IsDeleted).ToList();
            foreach (var category in categories)
            {
                var color = (Color)System.Windows.Media.ColorConverter.ConvertFromString(category.Color);

                SeriesCollection.Add(new PieSeries
                {
                    Title = category.Title,
                    Values = new ChartValues<int> { category.CountOfTasks },
                    Fill = new SolidColorBrush(color)
                });
            }
        }

        private void UpdateCategoryCounts()
        {
            using (var db = new ApplicationContext())
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
        }

        public BCommand UpdateTimerCommand { get; }
        public BCommand StartTimerCommand { get; }
        public BCommand ResetTimerCommand { get; }

        public DashbordViewModel()
        {
            UpdateTimerCommand = new BCommand(UpdateTimer, (o) => true);
            StartTimerCommand = new BCommand(CreateTimer, (o) => true);
            ResetTimerCommand = new BCommand(ResetTimer, (o) => true);

            _seriesCollection = new SeriesCollection();
            //ToggleIcon = "Play";
            IsButtonEnabled = true;
            IsRadioEnabled = true;
            _isTimerRunning = false;
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);

            SelectedTime = TimeSpan.Zero;

            CurrentTimer = db.Timers.FirstOrDefault(timer => timer.CurrentTime > TimeSpan.Zero);
            if (CurrentTimer != null)
            {
                var currTask = db.Tasks.FirstOrDefault(c => c.Id == CurrentTimer.TaskId);
                if (currTask != null)
                {
                    SelectedTime = CurrentTimer.CurrentTime;
                    SelectedTask = currTask.Title;
                    _isTimerRunning = true;
                    IsButtonEnabled = false;
                    IsRadioEnabled = false;
                    //ToggleIcon = "Pause";
                    _dispatcherTimer.Start();
                }
                else
                {
                    ResetTimer(CurrentTimer);
                }
            }

            using (var dbContext = new ApplicationContext())
            {
                TasksTitle = new ObservableCollection<string>(dbContext.Tasks.Where(c => !c.IsDeleted && c.Deadline.Date == DateTime.Now.Date && !c.IsDone).Select(c => c.Title));
            }
            LoadDiagramm();
            System.Threading.Tasks.Task.Run(() =>
            {
                LoadData();
                RunTimer();
            });
        }

    }
}
