using Businesslogic.Models;
using RegistrUserWPF.Enums.Description;
using RegistrUserWPF.Enums.EnumDescriprionViewModel;


namespace RegistrUserWPF.ViewModels
{
    public class PermissionViewModel : NotifyPropertyChanged
    {
        Permission SelectedPermission;
        Module module;
        EnumDescriptionProvider enumDescription;
        EnumViewModel<Modes> selectedMode;
        public PermissionViewModel(Permission selectedPermission)
        {
            SelectedPermission = selectedPermission;
            module = SelectedPermission.Module;
            enumDescription = new EnumDescriptionProvider();
            selectedMode = new EnumViewModel<Modes>(SelectedPermission.EditMode, enumDescription.GetDescription(SelectedPermission.EditMode));
        }

       public EnumViewModel<Modes> SelectedMode
        {
            get { return selectedMode; }
            set
            {
                selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }
        public string ModuleName
        {
            get { return module.Name; }
            set
            {
                module.Name = value;
                OnPropertyChanged("ModuleName");
            }
        }
    }
}
