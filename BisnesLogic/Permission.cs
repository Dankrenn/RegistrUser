using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesLogic
{
    public enum Modes
    {
        View,
        Edit,
        Admin
    }

    public class Permission
    {
       

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ModuleId { get; set; }
        public Modes Mode { get; set; }
    }
}
