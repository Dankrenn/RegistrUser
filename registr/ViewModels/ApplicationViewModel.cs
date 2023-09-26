using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using Businesslogic.Models;
using Businesslogic;
using RegistrUserWPF.Enums;
using RegistrUserWPF.Enums.EnumDescriprionViewModel;
using RegistrUserWPF.Enums.Description;
using Businesslogic.Repository;
using RegistrUserDAL.Repository;
using System.Windows.Media.Imaging;

namespace RegistrUserWPF.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        private IRepository<User> _repositoryUsers;
        private  ModuleRepository _repositoryModules;
        private PermissionRepository _repositoryPermissions;

        private UserViewModel _selectedUserViewModels;
        private ObservableCollection<UserViewModel> _collectionUserViewModels;
        private byte[] _userPhoto;
        private List<Module> _modulesList;
        private List<Permission> _permissionsList;
        private User user0 = new User();

        public ObservableCollection<UserViewModel> CollectionUserViewModel
        {
            get => _collectionUserViewModels;
            set
            {
                _collectionUserViewModels = value;
                OnPropertyChanged("CollectionUserViewModel");
            }
        }

        public UserViewModel SelectedUserViewModel
        {
            get => _selectedUserViewModels;
            set
            {
                _selectedUserViewModels = value;
                OnPropertyChanged("SelectedUserViewModel");
            }
        }

        public ApplicationViewModel()
        {
            _userPhoto = File.ReadAllBytes(@"C:\Users\danii\OneDrive\Рабочий стол\вв.jpg");
           // _repositoryModules = new ModuleRepository();
           // _modulesList = _repositoryModules.GetList().ToList();
           // _repositoryUsers = new UserRepository();
           // _repositoryPermissions = new PermissionRepository();
           // _collectionUserViewModels = _repositoryUsers.GetList().Select(b =>
           //new UserViewModel(b, new EnumValuesProvider(new EnumDescriptionProvider()))).ToObservableCollection();

            _modulesList = new List<Module>
            {
                new Module {Id = Guid.NewGuid(), Name="Продажи"},
                new Module {Id = Guid.NewGuid(), Name="Закупки"},
                new Module {Id = Guid.NewGuid(), Name="Аналитика"},
                new Module {Id = Guid.NewGuid(), Name="Администрирование"},
            };

            _permissionsList = new List<Permission>
            {
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Admin, ModuleId = _modulesList[0].Id, Module = _modulesList[0]},
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Edit, ModuleId = _modulesList[1].Id, Module = _modulesList[1] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.View, ModuleId = _modulesList[2].Id, Module = _modulesList[2] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Admin, ModuleId = _modulesList[3].Id, Module = _modulesList[3] }
            };

            _collectionUserViewModels = new ObservableCollection<UserViewModel>
            {

                 new UserViewModel(new User {FirsName ="Аркаша", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = _permissionsList, Photo = _userPhoto},new EnumValuesProvider(new EnumDescriptionProvider())),
                 new UserViewModel(new User {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Men, Blocked=false, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = _permissionsList, Photo = _userPhoto},new EnumValuesProvider(new EnumDescriptionProvider()))
            };
        }
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                    (_saveCommand = new RelayCommand(o =>
                    {
                        if (_selectedUserViewModels.FirsName == null || _selectedUserViewModels.LastName == null || _selectedUserViewModels.MidleName == null)
                            return;

                        if(_selectedUserViewModels == new UserViewModel(user0, new EnumValuesProvider(new EnumDescriptionProvider())))
                        {
                            return;
                        }
                        else
                        {
                            _collectionUserViewModels.Insert(_collectionUserViewModels.Count, SelectedUserViewModel);
                        }

                    }));
            }
        }
        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(o =>
                    {
                        user0 = new User()
                        {
                            FirsName = null,
                            LastName = null,
                            MidleName = null,
                            Birtchday = new DateTime(2000, 01, 01),
                            Gender = Gender.Men,
                            Blocked = false,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Id = Guid.NewGuid(),
                            Permission = _permissionsList,
                            Photo = _userPhoto
                        };
                        SelectedUserViewModel = new UserViewModel(user0, new EnumValuesProvider(new EnumDescriptionProvider()));
                    }));
            }
        }

        private RelayCommand _delCommand;
        public RelayCommand DelCommand
        {
            get
            {
                return _delCommand ??
                    (_delCommand = new RelayCommand(o =>
                    {
                            _collectionUserViewModels.Remove(SelectedUserViewModel);
                    }));
            }
        }

        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                  (_openCommand = new RelayCommand(o =>
                  {
                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
                      if (openFileDialog.ShowDialog() == true)
                      {
                          using (var stream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                          {
                              byte[] buffer = new byte[stream.Length];
                              stream.Read(buffer, 0, (int)stream.Length);
                              _selectedUserViewModels.Photo = buffer;
                          }
                      }
                  }));
            }
        }
    }
}
