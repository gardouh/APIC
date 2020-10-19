using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICH.Models.Repositories
{
    public class UserDbRepository : InterfaceUser<User>
    {
        UsersDbContext db;

        public UserDbRepository(UsersDbContext _db)
        {
            db = _db;
        }
        public void Add(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = Find(id);

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public User Find(int id)
        {
            var user = db.Users.SingleOrDefault(a => a.Id == id);

            return user;
        }

        public IList<User> List()
        {
            return db.Users.ToList();
        }

        public List<User> Search(string term)
        {
            return db.Users.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, User entity)
        {
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
