using Businesslogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL.ViewModels
{
    public class UserViewModel : NotifyPropertyChanged
    {
        public User SelectedUser;
        public ObservableCollection<PermissionViewModel> PermissionViewModels;

        public UserViewModel(User user)
        {
            SelectedUser = user;
            PermissionViewModels = new ObservableCollection<PermissionViewModel>(user.Permission.Select(x => new PermissionViewModel(x)));
        }
        public ObservableCollection<PermissionViewModel> PermissionViewModel
        {
            get => PermissionViewModels;
            set
            {
                PermissionViewModels = value;
                OnPropertyChanged("Permission");
            }
        }

        public string LastName
        {
            get => SelectedUser.LastName;
            set
            {
                SelectedUser.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string MidleName
        {
            get => SelectedUser.MidleName;
            set
            {
                SelectedUser.MidleName = value;
                OnPropertyChanged("MidleName");
            }
        }
        public string FirsName
        {
            get => SelectedUser.FirsName;
            set
            {
                SelectedUser.FirsName = value;
                OnPropertyChanged("FirsName");
            }
        }
        public DateTime Birtchday
        {
            get => SelectedUser.Birtchday;
            set
            {
                SelectedUser.Birtchday = value;
                OnPropertyChanged("Birtchday");
            }
        }
        public DateTime CreatedDate
        {
            get => SelectedUser.CreatedDate;
            set
            {
                SelectedUser.CreatedDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }
        public DateTime ModifiedDate
        {
            get => SelectedUser.ModifiedDate;
            set
            {
                SelectedUser.ModifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }
        public byte[] Photo
        {
            get => SelectedUser.Photo;
            set
            {
                SelectedUser.Photo = value;
                OnPropertyChanged("Photo");
            }
        }
        public Gender Gender
        {
            get => SelectedUser.Gender;
            set
            {
                if (SelectedUser.Gender == value)
                    return;
                SelectedUser.Gender = value;

                OnPropertyChanged("Gender");
                OnPropertyChanged("TranslateGender");
                OnPropertyChanged("ChangeSexMen");
                OnPropertyChanged("ChangeSexWomen");

            }
        }

        public bool ChangeSexMen
        {
            get => Gender.Men == SelectedUser.Gender ? true : false;
            set => Gender = value ? Gender.Men : Gender;
        }
        public bool ChangeSexWomen
        {
            get => Gender.Women == SelectedUser.Gender ? true : false;
            set => Gender = value ? Gender.Women : Gender;
        }

        public string TranslateGender
        {
            get => SelectedUser.Gender == Gender.Men ? "Мужчина" : "Женщина";
        }

        public bool Blocked
        {
            get => SelectedUser.Blocked;
            set
            {
                SelectedUser.Blocked = value;
                OnPropertyChanged("Blocked");
                OnPropertyChanged("TransletedBlocked");
            }
        }
        public string TransletedBlocked
        {
            get => SelectedUser.Blocked ? "Заблокирован" : "Доступен";
        }
    }
}
