using BisnesLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Module = BisnesLogic.Module;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;


namespace RegistrUserDAL
{
    public class ApplicationViewModel : NotifyPropertyChanged
    {
        public User User;
        private byte[] userPhoto;
        private ObservableCollection<User> _collectionUsers;
        public List<Module> ModulesList;
        public List<Permission> PermissionsList;

        public ObservableCollection<User> CollectionUsers
        {
            get { return _collectionUsers; }
            set
            {
                _collectionUsers = value;
                OnPropertyChanged("CollectionUsers");
            }
        }

        public User SelectedUser
        {
            get { return User; }
            set
            {
                User = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        public ApplicationViewModel()
        {
            userPhoto = File.ReadAllBytes(@"C:\Users\danii\OneDrive\Рабочий стол\вв.jpg");
            ModulesList = new List<Module>
            {
                new Module { Id = Guid.NewGuid(), Name = "Продажи" },
                new Module { Id = Guid.NewGuid(), Name = "Закупки" },
                new Module { Id = Guid.NewGuid(), Name = "Аналитика" },
                new Module { Id = Guid.NewGuid(), Name = "Администрирование" }
            };

            PermissionsList = new List<Permission>
            {
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = Modes.Admin,  ModuleId = ModulesList[0].Id },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = Modes.View, ModuleId = ModulesList[1].Id },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = Modes.View, ModuleId = ModulesList[2].Id },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), Mode = Modes.Edit, ModuleId = ModulesList[3].Id }
            };

            CollectionUsers = new ObservableCollection<User>
            {
                 new User {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto} ,
                 new User {FirsName ="Аркаша", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Women, Blocked=true, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto},
                 new User {FirsName ="Даниил", LastName="Руженко", MidleName="Евгеньевич", Birtchday=new DateTime(2004,11,02),
                    Gender=Gender.Men, Blocked=false, CreatedDate=DateTime.Now, ModifiedDate=DateTime.Now,
                    Id=Guid.NewGuid(), Permission = PermissionsList, Photo = userPhoto}
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
                        if (SelectedUser == null)
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
                        CollectionUsers.Insert(CollectionUsers.Count, user);
                        SelectedUser = user;
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
                        if(SelectedUser != null)
                            CollectionUsers.Remove(SelectedUser);
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
                      if (SelectedUser == null)
                          return;

                          OpenFileDialog openFileDialog = new OpenFileDialog();
                          openFileDialog.Filter = "Файлы изображений (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.png";
                          openFileDialog.ShowDialog();
                          string path = openFileDialog.FileName;
                          SelectedUser.Photo = File.ReadAllBytes(path);
                  }));
            }
        }
    }
}

