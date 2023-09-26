using Businesslogic;
using Businesslogic.Models;
using Businesslogic.Repository;
using RegistrUserDAL.Repository;
using RegistrUserWPF.Enums;
using RegistrUserWPF.Enums.EnumDescriprionViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Businesslogic.Models.Permission;

namespace RegistrUserWPF.ViewModels
{

    public class UserViewModel : NotifyPropertyChanged
    {
        private User _selectedUser;
        private ObservableCollection<PermissionViewModel> _permissionViewModels;
        private ObservableCollection<EnumViewModel<Modes>> _modesEnum;
        private ModuleRepository _moduleRepository = new ModuleRepository();

        public UserViewModel(User user, IEnumValuesProvider enumProvider)
        {
            _selectedUser = user;
           // List<Module> Modules = _moduleRepository.GetList().ToList();
            _permissionViewModels = new ObservableCollection<PermissionViewModel>(user.Permission.Select(x => new PermissionViewModel(x)));
            _modesEnum = enumProvider.GetValues<Modes>().ToObservableCollection();

        }
        public ObservableCollection<EnumViewModel<Modes>> ModesEnum
        {
            get { return _modesEnum; }
            set
            {
                _modesEnum = value;
                OnPropertyChanged("ModesEnum");
            }
        }
        public ObservableCollection<PermissionViewModel> PermissionsViewModel
        {
            get { return _permissionViewModels; }
            set
            {
                _permissionViewModels = value;
                OnPropertyChanged("PermissionsViewModel");
            }
        }

        public string LastName
        {
            get => _selectedUser.LastName;
            set
            {
                _selectedUser.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string MidleName
        {
            get => _selectedUser.MidleName;
            set
            {
                _selectedUser.MidleName = value;
                OnPropertyChanged("MidleName");
            }
        }
        public string FirsName
        {
            get => _selectedUser.FirsName;
            set
            {
                _selectedUser.FirsName = value;
                OnPropertyChanged("FirsName");
            }
        }
        public DateTime Birtchday
        {
            get => _selectedUser.Birtchday;
            set
            {
                _selectedUser.Birtchday = value;
                OnPropertyChanged("Birtchday");
            }
        }
        public DateTime CreatedDate
        {
            get => _selectedUser.CreatedDate;
            set
            {
                _selectedUser.CreatedDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }
        public DateTime ModifiedDate
        {
            get => _selectedUser.ModifiedDate;
            set
            {
                _selectedUser.ModifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }
        public byte[] Photo
        {
            get => _selectedUser.Photo;
            set
            {
                _selectedUser.Photo = value;
                OnPropertyChanged("Photo");
            }
        }
        public Gender Gender
        {
            get => _selectedUser.Gender;
            set
            {
                if (_selectedUser.Gender == value)
                    return;
                _selectedUser.Gender = value;

                OnPropertyChanged("Gender");
                OnPropertyChanged("TranslateGender");
                OnPropertyChanged("ChangeSexMen");
                OnPropertyChanged("ChangeSexWomen");

            }
        }

        public bool ChangeSexMen
        {
            get => Gender.Men == _selectedUser.Gender ? true : false;
            set => Gender = value ? Gender.Men : Gender;
        }
        public bool ChangeSexWomen
        {
            get => Gender.Women == _selectedUser.Gender ? true : false;
            set => Gender = value ? Gender.Women : Gender;
        }

        public string TranslateGender
        {
            get => _selectedUser.Gender == Gender.Men ? "Мужчина" : "Женщина";
        }

        public bool Blocked
        {
            get => _selectedUser.Blocked;
            set
            {
                _selectedUser.Blocked = value;
                OnPropertyChanged("Blocked");
                OnPropertyChanged("TransletedBlocked");
            }
        }
        public string TransletedBlocked
        {
            get => _selectedUser.Blocked ? "Заблокирован" : "Доступен";
        }
    }
}
