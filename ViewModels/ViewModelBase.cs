using PROG6212.Models;
using PROG6212.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PROG6212.ViewModels
{
    public class ViewModelBase : ObservableCollection<Module>
    {

        public AddModuleCommand AddModuleCommand { get; set; }
        public AddStudyingDateCommand AddStudyingDateCommand { get; set; }

        public ViewModelBase()
        {
            this.AddModuleCommand = new AddModuleCommand(this);
            this.AddStudyingDateCommand = new AddStudyingDateCommand(this);

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

        public void AddModuleMethod(Module module)
        {
            Module m = new Module();
            m.ModuleCode = module.ModuleCode;
            m.ModuleName = module.ModuleName;
            m.ClassHoursPerWeek = module.ClassHoursPerWeek;
            m.Credits = module.Credits;

            Add(m);
        }

        public void AddStudyingDateMethod(Module mod)
        {
            foreach (var module in this)
            {
                if(module.ModuleCode == mod.ModuleCode)
                {
                    module.HoursStudiedToday = mod.HoursStudiedToday;
                }
                int x = 0;
            }

        }

    }
}
