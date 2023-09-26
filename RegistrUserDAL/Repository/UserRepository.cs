using Businesslogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Businesslogic.Repository;

namespace RegistrUserDAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationContext db;

        public UserRepository()
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
        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public User GetID(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetList()
        {
            return db.Users.Include(x => x.Permission);
        }

        public void Save(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
