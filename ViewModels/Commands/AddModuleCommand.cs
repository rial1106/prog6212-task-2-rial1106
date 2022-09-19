using PROG6212.Models;
using System;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;

namespace PROG6212.ViewModels.Commands
{
    public class AddModuleCommand : ICommand
    {

        public ViewModelBase ViewModel { get; set; }

        public AddModuleCommand(ViewModelBase viewModel)
        {
            this.ViewModel = viewModel;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            var tmp = parameter as Module;
            this.ViewModel.AddModuleMethod(tmp);
        }
    }
}
