using Businesslogic;
using Businesslogic.Models;
using RegistrUserDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace registr.View
{
    /// <summary>
    /// Логика взаимодействия для UserControlListbox.xaml
    /// </summary>
    public partial class UserControlListbox : UserControl
    {
        List<Module> ModulesList = new List<Module>
            {
                new Module { Id = Guid.NewGuid(), Name = "Продажи" },
                new Module { Id = Guid.NewGuid(), Name = "Закупки" },
                new Module { Id = Guid.NewGuid(), Name = "Аналитика" },
                new Module { Id = Guid.NewGuid(), Name = "Администрирование" }
            };

        List<Permission> PermissionsList = new List<Permission>
            {
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Admin},
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.View },
                new Permission {Id = Guid.NewGuid(), UserId = Guid.NewGuid(), EditMode = Permission.Modes.Edit }
            };
public UserControlListbox()
        {
            InitializeComponent();
            DataContext = this;
            //DataContext = new UserViewModel(new User
            //{
            //    FirsName = "Даниил",
            //    LastName = "Руженко",
            //    MidleName = "Евгеньевич",
            //    Birtchday = new DateTime(2004, 11, 02),
            //    Gender = Gender.Women,
            //    Blocked = true,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    Id = Guid.NewGuid(),
            //    Permission = PermissionsList,
            //    Photo = null
            //}); ;
        }
    }
}
