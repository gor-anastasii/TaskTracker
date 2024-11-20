using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class Timer
    {
        public int TimerId { get; set; }
        public TimeSpan Duration { get; set; }
        public TimeSpan CurrentTime { get; set; }
        public bool IsPause { get; set; }
        public int TaskId { get; set; }
    }
}
