using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TodoApp.Infrastructure.Commands
{
    public class BCommand(Action<object> ex, Func<object, bool> canEx) : ICommand
    {
        private readonly Action<object> _execute = ex;
        private readonly Func<object, bool> _canExecute = canEx;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object? parameter) => _execute?.Invoke(parameter);
    }
}
