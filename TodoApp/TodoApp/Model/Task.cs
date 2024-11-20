using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Model
{
    public class Task 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime СreationTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        public bool IsDone { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public int? PeriodId { get; set; }
    }
}
