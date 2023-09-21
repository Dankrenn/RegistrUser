using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.Models
{
    public class Permission
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Modes EditMode { get; set; }
        public Guid ModuleId { get; set; }
        public Module Module { get; set; }

    }
}

