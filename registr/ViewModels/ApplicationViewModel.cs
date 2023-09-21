﻿using System;
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

namespace RegistrUserWPF.ViewModels
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        IRepository<User> repositoryUsers;
        public UserViewModel SelectedUserViewModels;
        public ObservableCollection<UserViewModel> CollectionUserViewModels;
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
            repositoryUsers = new PostgreSQLUserRepository();
            ObservableCollection<User> users = new ObservableCollection<User>();
            users = new ObservableCollection<User>(repositoryUsers.GetUserList());
            foreach (var item in users)
            {
                CollectionUserViewModel.Add(new UserViewModel(item, new EnumValuesProvider(new EnumDescriptionProvider())));
            }

            ModulesList = new List<Module>
            {
                new Module {Id = Guid.NewGuid(), Name="Продажи"},
                new Module {Id = Guid.NewGuid(), Name="Закупки"},
                new Module {Id = Guid.NewGuid(), Name="Аналитика"},
                new Module {Id = Guid.NewGuid(), Name="Администрирование"},
            };

            PermissionsList = new List<Permission>
            {
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Admin, ModuleId = ModulesList[0].Id, Module = ModulesList[0]},
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Edit, ModuleId = ModulesList[1].Id, Module = ModulesList[1] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.View, ModuleId = ModulesList[2].Id, Module = ModulesList[2] },
                new Permission { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Modes.Admin, ModuleId = ModulesList[3].Id, Module = ModulesList[3] }
            }; ;
            CollectionUserViewModels = new ObservableCollection<UserViewModel>
            {

                 new UserViewModel(new User {FirsName ="Аркаша", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto},new EnumValuesProvider(new EnumDescriptionProvider())),
                 new UserViewModel(new User {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Men, Blocked=false, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto},new EnumValuesProvider(new EnumDescriptionProvider()))
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
                        CollectionUserViewModels.Insert(CollectionUserViewModels.Count, SelectedUserViewModel);
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
                        User user = new User()
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
                                Permission = PermissionsList,
                                Photo = userPhoto
                        };
                        //CollectionUserViewModels.Insert(CollectionUserViewModels.Count, new UserViewModel(user));
                        SelectedUserViewModel = new UserViewModel(user, new EnumValuesProvider(new EnumDescriptionProvider()));
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
                      {
                          return;
                      }

                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";

                      if (openFileDialog.ShowDialog() == true)
                      {
                          string path = openFileDialog.FileName;
                          SelectedUserViewModel.Photo = File.ReadAllBytes(path);
                      }
                  }));
            }
        }
    }
}
