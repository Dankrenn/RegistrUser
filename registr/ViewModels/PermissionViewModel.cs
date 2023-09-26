using Businesslogic.Models;
using RegistrUserDAL.Repository;
using RegistrUserWPF.Enums.Description;
using RegistrUserWPF.Enums.EnumDescriprionViewModel;
using System;

namespace RegistrUserWPF.ViewModels
{
    public class PermissionViewModel : NotifyPropertyChanged
    {
        private Permission _selectedPermission;
        private Module _module;
        private EnumDescriptionProvider _enumDescription;
        private EnumViewModel<Modes> _selectedMode;
        private ModuleRepository _moduleRepository;
        public PermissionViewModel(Permission selectedPermission)
        {
            _selectedPermission = selectedPermission;
            _moduleRepository = new ModuleRepository();
            //_module = _moduleRepository.GetID(Convert.ToInt32(_selectedPermission.ModuleId));
            _enumDescription = new EnumDescriptionProvider();
            _selectedMode = new EnumViewModel<Modes>(_selectedPermission.EditMode, _enumDescription.GetDescription(_selectedPermission.EditMode));
        }

       public EnumViewModel<Modes> SelectedMode
        {
            get { return _selectedMode; }
            set
            {
                _selectedMode = value;
                OnPropertyChanged("SelectedMode");
            }
        }
        public string ModuleName
        {
            get { return _module.Name; }
            set
            {
                _module.Name = value;
                OnPropertyChanged("ModuleName");
            }
        }
    }
}
