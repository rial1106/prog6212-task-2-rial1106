using PROG6212.Models;
using System;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;

namespace PROG6212.ViewModels.Commands
{
    public class AddStudyingDateCommand : ICommand
    {

        public ViewModelBase ViewModel { get; set; }

        public AddStudyingDateCommand(ViewModelBase viewModel)
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

            var parameters = (object[])parameter;

            if (parameters[0] != null && parameters[1] != null)
            {
                Module module = (Module)parameters[0];
                this.ViewModel.AddStudyingDateMethod(module.ModuleCode, Double.Parse(parameters[1].ToString()));
            }

        }
    }
}
