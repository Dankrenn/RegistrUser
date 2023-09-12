﻿using Businesslogic;
using Businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL.Migretion
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DbConnection")
        { 
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        //protected override void OnConfiguring()
        //{
        //    ("Server=localhost;Port=5432;Username=postgres;Password=1234;Database=RegistrUsers");
        //}
    }

}