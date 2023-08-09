using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BisnesLogic
{
    public enum Gender
    {
        Men,
        Women
    }
    public class User : NotifyPropertyChanged
    {
        [Key]
        public Guid Id { get; set; }
        private string _lastName;
        private string _midleName;
        private string _firsName;
        private DateTime _birtchday;
        private DateTime _createdDate;
        private DateTime _modifiedDate;
        private byte[] _photo;
        private Gender _gender;
        private bool _blocked;
        private List<Permission> _permission;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string MidleName
        {
            get
            {
                return _midleName;
            }
            set
            {
                _midleName = value;
                OnPropertyChanged("MidleName");
            }
        }
        public string FirsName
        {
            get
            {
                return _firsName;
            }
            set
            {
                _firsName = value;
                OnPropertyChanged("FirsName");
            }
        }
        public DateTime Birtchday
        {
            get
            {
                return _birtchday;
            }
            set
            {
                _birtchday = value;
                OnPropertyChanged("Birtchday");
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            set
            {
                _createdDate = value;
                OnPropertyChanged("CreatedDate");
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return _modifiedDate;
            }
            set
            {
                _modifiedDate = value;
                OnPropertyChanged("ModifiedDate");
            }
        }
        public byte[] Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                _photo = value;
                OnPropertyChanged("Photo");
            }
        }
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (_gender == value)
                    return;
                _gender = value;

                OnPropertyChanged("Gender");
                OnPropertyChanged("TranslateGender");
                OnPropertyChanged("ChangeSexMen");
                OnPropertyChanged("ChangeSexWomen");
                
            }
        }

        public bool ChangeSexMen
        {
           get { return Gender.Men == _gender ? true : false; }
            set { Gender = value ? Gender.Men : Gender; }
        }
        public bool ChangeSexWomen
        {
            get { return Gender.Women == _gender ? true : false; }
            set { Gender = value ? Gender.Women : Gender; }
        }

        public string TranslateGender
        {
            get { return _gender == Gender.Men ? "Мужчина" : "Женщина"; }
        }

        public bool Blocked
        {
            get { return _blocked; }
            set
            {
                _blocked = value;
                OnPropertyChanged("Blocked");
                OnPropertyChanged("TransletedBlocked");
            }
        }
        public string TransletedBlocked
        {
            get { return _blocked ? "Заблокирован" : "Доступен"; }
        }

        public List<Permission> Permission
        {
            get
            {
                return _permission;
            }
            set
            {
                _permission = value;
                OnPropertyChanged("Permission");
            }
        }
    }
}
