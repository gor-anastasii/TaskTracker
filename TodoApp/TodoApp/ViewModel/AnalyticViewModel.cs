using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.EF.Context;
using TodoApp.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using TodoApp.Infrastructure.Commands;

namespace TodoApp.ViewModel
{
    public class AnalyticViewModel : Base.ViewModel
    {
        ApplicationContext db = new();

        #region Propertis ond Collections

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

        private ObservableCollection<Model.Task>? _taskOfDate;
        public ObservableCollection<Model.Task>? TaskOfDate
        {
            get => _taskOfDate;
            set => Set(ref _taskOfDate, value);
        }

        private string _periodStatistic;
        public string PeriodStatistic
        {
            get => _periodStatistic;
            set => Set(ref _periodStatistic, value);
        }

        private int _taskStatistic;
        public int TaskStatistic
        {
            get => _taskStatistic;
            set => Set(ref _taskStatistic, value);
        }

        private int _doneTaskStatistic;
        public int DoneTaskStatistic
        {
            get => _doneTaskStatistic;
            set => Set(ref _doneTaskStatistic, value);
        }

        private int _notDoneTaskStatistic;
        public int NotDoneTaskStatistic
        {
            get => _notDoneTaskStatistic;
            set => Set(ref _notDoneTaskStatistic, value);
        }

        private int _catStatistic;
        public int CatStatistic
        {
            get => _catStatistic;
            set => Set(ref _catStatistic, value);
        }

        private int _catDeleted;
        public int CatDeleted
        {
            get => _catDeleted;
            set => Set(ref _catDeleted, value);
        }

        private int _taskDeleted;
        public int TaskDeleted
        {
            get => _taskDeleted;
            set => Set(ref _taskDeleted, value);
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (Set(ref _selectedDate, value))
                {
                    IsDateSelected = (_selectedDate != default(DateTime));
                }
            }
        }

        private DateTime _selectedDateOfTask;
        public DateTime SelectedDateOfTask
        {
            get => _selectedDateOfTask;
            set => Set(ref _selectedDateOfTask, value);
        }

        private int _dateTask;
        public int DateTask
        {
            get => _dateTask;
            set => Set(ref _dateTask, value);
        }

        private int _dateDoneTask;
        public int DateDoneTask
        {
            get => _dateDoneTask;
            set => Set(ref _dateDoneTask, value);
        }

        private int _dateNotDoneTask;
        public int DateNotDoneTask
        {
            get => _dateNotDoneTask;
            set => Set(ref _dateNotDoneTask, value);
        }

        private int _datePeriodTask;
        public int DatePeriodTask
        {
            get => _datePeriodTask;
            set => Set(ref _datePeriodTask, value);
        }

        private bool _isDateSelected;
        public bool IsDateSelected
        {
            get { return _isDateSelected; }
            set
            {
                _isDateSelected = value;
                OnPropertyChanged(nameof(IsDateSelected));
            }
        }

        #endregion

        #region Commands

        private void DayPeriod(object e)
        {
            PeriodStatistic = "Day";

            TaskStatistic = TasksDT.Where(t => t.СreationTime.Date == DateTime.Now.Date && !t.IsDeleted).Count();
            DoneTaskStatistic = TasksDT.Where(t => t.СreationTime.Date == DateTime.Now.Date && !t.IsDeleted && t.IsDone).Count();
            NotDoneTaskStatistic = TasksDT.Where(t => t.СreationTime.Date == DateTime.Now.Date && !t.IsDeleted && !t.IsDone).Count();
            CatStatistic = CategoriesDT.Where(c => c.СreationTime.Date == DateTime.Now.Date && !c.IsDeleted).Count();
            CatDeleted = CategoriesDT.Where(c => c.СreationTime.Date == DateTime.Now.Date && c.IsDeleted).Count();
            TaskDeleted = TasksDT.Where(t => t.СreationTime.Date == DateTime.Now.Date && t.IsDeleted).Count();
        }

        private void WeekPeriod(object e)
        {
            PeriodStatistic = "Week";

            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            DateTime endOfWeek = startOfWeek.AddDays(6);

            TaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfWeek && t.СreationTime <= endOfWeek && !t.IsDeleted);
            DoneTaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfWeek && t.СreationTime.Date <= endOfWeek && !t.IsDeleted && t.IsDone);
            NotDoneTaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfWeek && t.СreationTime.Date <= endOfWeek && !t.IsDeleted && !t.IsDone);
            CatStatistic = CategoriesDT.Count(c => c.СreationTime.Date >= startOfWeek && c.СreationTime.Date <= endOfWeek && !c.IsDeleted);
            CatDeleted = CategoriesDT.Count(c => c.СreationTime.Date >= startOfWeek && c.СreationTime.Date <= endOfWeek && c.IsDeleted);
            TaskDeleted = TasksDT.Count(t => t.СreationTime.Date >= startOfWeek && t.СreationTime.Date <= endOfWeek && t.IsDeleted);
        }
        private void MonthPeriod(object e)
        {
            PeriodStatistic = "Month";

            DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            TaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfMonth && t.СreationTime <= endOfMonth && !t.IsDeleted);
            DoneTaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfMonth && t.СreationTime.Date <= endOfMonth && !t.IsDeleted && t.IsDone);
            NotDoneTaskStatistic = TasksDT.Count(t => t.СreationTime.Date >= startOfMonth && t.СreationTime.Date <= endOfMonth && !t.IsDeleted && !t.IsDone);
            CatStatistic = CategoriesDT.Count(c => c.СreationTime.Date >= startOfMonth && c.СreationTime.Date <= endOfMonth && !c.IsDeleted);
            CatDeleted = CategoriesDT.Count(c => c.СreationTime.Date >= startOfMonth && c.СreationTime.Date <= endOfMonth && c.IsDeleted);
            TaskDeleted = TasksDT.Count(t => t.СreationTime.Date >= startOfMonth && t.СreationTime.Date <= endOfMonth && t.IsDeleted);
        }

        private void ShowTaskOfDate(object e)
        {
            SelectedDateOfTask = SelectedDate;

            if (TasksDT != null)
            {
                TaskOfDate = new ObservableCollection<Model.Task>(
                    TasksDT.Where(t => t.Deadline.Date == SelectedDate.Date && !t.IsDeleted)
                );
            }

            DateTask = TasksDT.Where(t => t.Deadline.Date == SelectedDate.Date && !t.IsDeleted).Count();
            DateDoneTask = TasksDT.Where(t => t.Deadline.Date == SelectedDate.Date && !t.IsDeleted && t.IsDone).Count();
            DateNotDoneTask = TasksDT.Where(t => t.Deadline.Date == SelectedDate.Date && !t.IsDeleted && !t.IsDone).Count();
            DatePeriodTask = TasksDT.Where(t => t.Deadline.Date == SelectedDate.Date && t.PeriodId != null && !t.IsDeleted).Count();
        }

        private bool CanShowTaskOfDate(object e)
        {
            return IsDateSelected;
        }

        #endregion

        public async void LoadData()
        {
            await db.Tasks.LoadAsync();
            TasksDT = db.Tasks.Local.ToObservableCollection();

            await db.Categories.LoadAsync();
            CategoriesDT = db.Categories.Local.ToObservableCollection();

            await db.PeriodTasks.LoadAsync();
            PeriodTasksDT = db.PeriodTasks.Local.ToObservableCollection();
        }

        public BCommand DayPeriodCommand { get; }
        public BCommand WeekPeriodCommand { get; }
        public BCommand MonthPeriodCommand { get; }
        public BCommand ShowTaskOfDateCommand { get; }
        public AnalyticViewModel ()
        {
            LoadData();
            DayPeriodCommand = new BCommand(DayPeriod, (o) => true);
            WeekPeriodCommand = new BCommand(WeekPeriod, (o) => true);
            MonthPeriodCommand = new BCommand(MonthPeriod, (o) => true);
            ShowTaskOfDateCommand = new BCommand(ShowTaskOfDate, CanShowTaskOfDate);

            SelectedDateOfTask = DateTime.Now;
            IsDateSelected = false;
        }

    }
}
