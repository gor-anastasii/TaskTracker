using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using TodoApp.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.ViewModel
{
    public class NotifyViewModel : Base.ViewModel
    {
        ApplicationContext db = new();

        private ObservableCollection<Model.Task>? _tasksDT;
        public ObservableCollection<Model.Task>? TasksDT
        {
            get => _tasksDT;
            set => Set(ref _tasksDT, value);
        }

        private async void LoadData()
        {
            await db.Tasks.LoadAsync();
            var sortedTasks = db.Tasks.Local.Where(task => !task.IsDeleted && !task.IsDone && task.Deadline.Date < DateTime.Today && !task.PeriodId.HasValue);
            TasksDT = new ObservableCollection<Model.Task>(sortedTasks);
        }
        public NotifyViewModel()
        {
            LoadData();
        }

    }
}
