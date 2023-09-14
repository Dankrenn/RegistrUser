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

namespace RegistrUserDAL.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        public UserViewModel SelectedUserViewModels;
        public ObservableCollection<UserViewModel> CollectionUserViewModels;
        public ObservableCollection<ModuleViewModel> CollectionModuleViewModels;
        public ObservableCollection<PermissionViewModel> CollectionPermissionViewModels;
        public byte[] userPhoto;

        public List<Module> ModulesList;

        public List<Permission> PermissionsList;


        public ObservableCollection<UserViewModel> CollectionUserViewModel
        {
            get => CollectionUserViewModels;
            set
            {
                CollectionUserViewModels = value;
                OnPropertyChanged("CollectionUserViewModel");
            }
        }

        public UserViewModel SelectedUserViewModel
        {
            get => SelectedUserViewModels;
            set
            {
                SelectedUserViewModels = value;
                OnPropertyChanged("SelectedUserViewModel");
            }
        }
        public ApplicationViewModel()
        {
            userPhoto = File.ReadAllBytes(@"C:\Users\danii\OneDrive\Рабочий стол\вв.jpg");

            CollectionModuleViewModels = new ObservableCollection<ModuleViewModel>
            {
                new ModuleViewModel(new Module { Id = Guid.NewGuid(), Name = "Продажи" }),
                new ModuleViewModel(new Module { Id = Guid.NewGuid(), Name = "Закупки" }),
                new ModuleViewModel(new Module { Id = Guid.NewGuid(), Name = "Аналитика" }),
                new ModuleViewModel(new Module { Id = Guid.NewGuid(), Name = "Администрирование" }),
            };

            CollectionPermissionViewModels = new ObservableCollection<PermissionViewModel>
            {
                new PermissionViewModel( new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Admin}),
                new PermissionViewModel(new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View }),
                new PermissionViewModel(new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View }),
                new PermissionViewModel(new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Edit })
            };

            ModulesList = new List<Module>
            {
                new Module { Id = Guid.NewGuid(), Name = "Продажи" },
                new Module { Id = Guid.NewGuid(), Name = "Закупки" },
                new Module { Id = Guid.NewGuid(), Name = "Аналитика" },
                new Module { Id = Guid.NewGuid(), Name = "Администрирование" }
            };

            PermissionsList = new List<Permission>
            {
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Admin},
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Edit }
            };

            CollectionUserViewModels = new ObservableCollection<UserViewModel>
            {
                 new UserViewModel(new User  {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto}) ,
                 new UserViewModel(new User {FirsName ="Аркаша", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto}),
                 new UserViewModel(new User {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Men, Blocked=false, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto})
            };


        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(o =>
                    {
                        User user;
                        if (SelectedUserViewModels == null)
                        {
                            user = new User()
                            {
                                FirsName = "Хар",
                                LastName = "Иванов",
                                MidleName = "Иванович",
                                Birtchday = new DateTime(2000, 01, 01),
                                Gender = Gender.Men,
                                Blocked = false,
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                Id = Guid.NewGuid(),
                                Permission = PermissionsList,
                                Photo = userPhoto
                            };
                        }
                        else
                        {
                            user = new User()
                            {
                                FirsName = "Иван",
                                LastName = "Иванов",
                                MidleName = "Иванович",
                                Birtchday = new DateTime(2000, 01, 01),
                                Gender = Gender.Men,
                                Blocked = false,
                                CreatedDate = DateTime.Now,
                                ModifiedDate = DateTime.Now,
                                Id = Guid.NewGuid(),
                                Permission = PermissionsList,
                                Photo = userPhoto
                            };
                        }
                        CollectionUserViewModels.Insert(CollectionUserViewModels.Count, new UserViewModel(user));
                        SelectedUserViewModel = new UserViewModel(user);
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
                        if (SelectedUserViewModel != null)
                            CollectionUserViewModels.Remove(SelectedUserViewModel);
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
                      if (SelectedUserViewModel == null)
                          return;

                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                      openFileDialog.ShowDialog();
                      string path = openFileDialog.FileName;
                      SelectedUserViewModel.Photo = File.ReadAllBytes(path);
                  }));
            }
        }
    }
}
