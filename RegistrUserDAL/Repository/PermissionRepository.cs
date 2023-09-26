using Businesslogic;
using Businesslogic.Models;
using Businesslogic.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL.Repository
{
    public class PermissionRepository :IRepository<Permission>
    {
        private ApplicationContext db;

        public PermissionRepository()
        {
            db = new ApplicationContext();
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
        public void Create(Permission item)
        {
            db.Permissions.Add(item);
        }

        public void Delete(int id)
        {
            Permission item = db.Permissions.Find(id);
            if (item != null)
                db.Permissions.Remove(item);
        }

        public Permission GetID(int id)
        {
            return db.Permissions.Find(id);
        }

        public IEnumerable<Permission> GetList()
        {
            return db.Permissions;
        }
        public void Save(Permission item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
