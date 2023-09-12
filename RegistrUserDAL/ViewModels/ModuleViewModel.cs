using Businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL.ViewModels
{
    public class ModuleViewModel : NotifyPropertyChanged
    {
        public Module SelectedModule;
        public ModuleViewModel(Module selectedModule)
        {
            SelectedModule = selectedModule;
        }

        public string Name
        {
            get => SelectedModule.Name;
            set
            {
                SelectedModule.Name = value;
                OnPropertyChanged("NameModule");
            }
        }
    }
}
