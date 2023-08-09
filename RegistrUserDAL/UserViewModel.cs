using BisnesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL
{
    public class UserViewModel : NotifyPropertyChanged
    {
        public User User;

        public User SelectedUser
        {
            get { return User; }
            set
            {
                User = value;
                OnPropertyChanged("SelectedUser");
            }
        }
    }
}
