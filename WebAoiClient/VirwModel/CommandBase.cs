using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebAoiClient.VirwModel
{
    public class CommandBase : ICommand
    {
        private readonly Action<object> _action;
        private readonly Predicate<object?> _canExecute;

        public CommandBase(Action<object?> execute)
           : this(execute, null)
        {
        }

        public CommandBase(Action<object?> action, Predicate<object?> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        //do zaimplementowania póżniej
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke(parameter);
        }
    }
}