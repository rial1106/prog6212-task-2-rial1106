using PROG6212.Data;
using PROG6212.Models;
using PROG6212.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using Module = PROG6212.Models.Module;

namespace PROG6212.ViewModels
{
    /* This class is a ViewModel (MVVM) for the list of modules.
     * Implementing ObservableCollection<Module> notifies the UI that a change has been made
     * to the collection and that the UI should update.
     */
    public class ViewModelBase : ObservableCollection<Module>
    {

        public AddModuleCommand AddModuleCommand { get; set; } // Function to add a module.
        public AddStudyingDateCommand AddStudyingDateCommand { get; set; } // Function to add a studying date.

        public ViewModelBase()
        {
            this.AddModuleCommand = new AddModuleCommand(this);
            this.AddStudyingDateCommand = new AddStudyingDateCommand(this);


        }

        // Manually add a Module from inputted values on the UI.
        public void AddModuleMethod(Module module)
        {
            Module m = new Module();
            m.moduleCode = module.moduleCode;
            m.moduleName = module.moduleName;
            m.classHoursPerWeek = module.classHoursPerWeek;
            m.credits = module.credits;

            Add(m);
        }

        // Add a studying date from inputted values on the UI.
        public void AddStudyingDateMethod(string moduleCode, double hours)
        {
            foreach (var module in this) // Loop over all added modules.
            {
                if (module.moduleCode == moduleCode) // If the module code matches a module add the studying date to that module.
                {
                    StudyDate studyDate = new StudyDate();
                    studyDate.hoursStudied = hours;
                    //module.AddStudyDate(studyDate);
                }
            }

        }

    }
}
