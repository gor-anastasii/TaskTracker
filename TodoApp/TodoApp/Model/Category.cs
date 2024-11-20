using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Color { get; set; }
        public int CountOfDone { get; set; }
        public int CountOfTasks { get; set; }
        public DateTime СreationTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
