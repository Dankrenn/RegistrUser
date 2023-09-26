using Businesslogic;
using Businesslogic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrUserDAL.Repository
{
    public class ModuleRepository
    {
        private ApplicationContext db;

        public ModuleRepository()
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
        public void Create(Module item)
        {
            db.Modules.Add(item);
        }

        public void Delete(int id)
        {
            Module item = db.Modules.Find(id);
            if (item != null)
                db.Modules.Remove(item);
        }

        public Module GetID(int id)
        {
            return db.Modules.Find(id);
        }

        public IEnumerable<Module> GetList()
        {
            return db.Modules;
        }
        public void Save(Module item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}

