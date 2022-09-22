using PROG6212.Models;
using PROG6212.ViewModels.Commands;
using System.Collections.ObjectModel;

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


            // Add Placeholder Modules to the UI.
            Add(new Module()
            {
                ModuleName = "Databases 1A",
                ModuleCode = "DBAS6211",
                Credits = 40,
                ClassHoursPerWeek = 20
            });

            Add(new Module()
            {
                ModuleName = "Cloud Development 2A",
                ModuleCode = "CLDV6212",
                Credits = 50,
                ClassHoursPerWeek = 10
            });

            Add(new Module()
            {
                ModuleName = "Network Engineering 2A",
                ModuleCode = "NWEG5211",
                Credits = 45,
                ClassHoursPerWeek = 36
            });
        }

        // Manually add a Module from inputted values on the UI.
        public void AddModuleMethod(Module module)
        {
            Module m = new Module();
            m.ModuleCode = module.ModuleCode;
            m.ModuleName = module.ModuleName;
            m.ClassHoursPerWeek = module.ClassHoursPerWeek;
            m.Credits = module.Credits;

            Add(m);
        }

        // Add a studying date from inputted values on the UI.
        public void AddStudyingDateMethod(string moduleCode, double hours)
        {
            foreach (var module in this) // Loop over all added modules.
            {
                if (module.ModuleCode == moduleCode) // If the module code matches a module add the studying date to that module.
                {
                    StudyDate studyDate = new StudyDate();
                    studyDate.HoursStudied = hours;
                    module.AddStudyDate(studyDate);
                }
            }

        }

    }
}
