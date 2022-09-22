using PROG6212.Models;
using System;
using System.Windows.Input;

namespace PROG6212.ViewModels.Commands
{

    /* This class allows us to add a module to our ObservableCollection<Module>.
     * The ICommand interface provides a callback to the UI.
     */
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
