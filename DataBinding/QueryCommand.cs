using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPFDemo.DataBinding {
    public class QueryCommand : ICommand {

        private Action executeAction;
        private Func<bool> canExecuteFun;

        public QueryCommand(Action executeAction) : this(executeAction, null) {

        }

        public QueryCommand(Action executeAction, Func<bool> canExecuteFun) {
            this.executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            this.canExecuteFun = canExecuteFun;
        }

        public void Execute(object parameter) {
            executeAction();
        }

        public bool CanExecute(object parameter) {
            return canExecuteFun == null ? true : canExecuteFun();
        }

        public event EventHandler CanExecuteChanged {
            add {
                if (canExecuteFun != null) {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove {
                if (canExecuteFun != null) {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
    }
}
