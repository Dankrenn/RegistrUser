using Businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Businesslogic.Models.Permission;

namespace RegistrUserDAL.ViewModels
{
    public class PermissionViewModel : NotifyPropertyChanged
    {
        public Permission SelectedPermission;
        public ObservableCollection<ModuleViewModel> ModuleViewModels;
        public PermissionViewModel(Permission selectedPermission)
        {
            SelectedPermission = selectedPermission;
            // ModuleViewModels = new ObservableCollection<ModuleViewModel>(selectedPermission.Module.Select(x => new ModuleViewModel(x)));
        }

        public Modes EditMode
        {
            get => SelectedPermission.EditMode;
            set
            {
                SelectedPermission.EditMode = value;
                OnPropertyChanged("EditMode");
            }
        }

        public ObservableCollection<ModuleViewModel> Module
        {
            get => ModuleViewModels;
            set
            {
                ModuleViewModels = value;
                OnPropertyChanged("Module");
            }
        }
    }
}
