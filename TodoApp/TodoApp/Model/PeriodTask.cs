using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class PeriodTask
    {
        public int PeriodTaskId { get; set; }
        public DateTime beginPeriodTask { get; set; }
        public DateTime endPeriodTask { get; set;}
        public string Frequency { get; set; }
    }
}
