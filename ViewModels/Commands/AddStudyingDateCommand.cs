using PROG6212.Models;
using System;
using System.Windows.Input;

namespace PROG6212.ViewModels.Commands
{
    /* This class allows us to add a StudyDate to a Module in our ObservableCollection<Module> ViewModel.
     * The ICommand interface provides a callback to the UI.
     */
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
                this.ViewModel.AddStudyingDateMethod(module.moduleCode, Double.Parse(parameters[1].ToString()));
            }

        }
    }
}
