using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.ViewModel;

namespace TodoApp.Global
{
    public static class Globals
    {
        private static TaskViewModel mvm = new TaskViewModel();

        public static TaskViewModel GetMVM()
        {
            if(mvm == null)
            {
                return mvm = new TaskViewModel();
            }
            return mvm;
        }
    }
}
