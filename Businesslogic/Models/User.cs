using Businesslogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic
{
    public enum Gender
    {
        Men,
        Women
    }
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public string FirsName { get; set; }
        public DateTime Birtchday { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public byte[] Photo { get; set; }
        public Gender Gender { get; set; }
        public bool Blocked { get; set; }
        public List<Permission> Permission { get; set; }


    }
}
