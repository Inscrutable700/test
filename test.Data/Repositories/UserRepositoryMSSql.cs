using System.Data.Entity;
using System.Linq;
using test.Data.Models;

namespace test.Data.Repositories
{
    public class UserRepositoryMSSql : IUserRepository
    {
        private DataContext dataContext;

        public UserRepositoryMSSql(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public User Add(User entity)
        {
            User user = this.dataContext.Users.Add(entity);
            this.dataContext.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            User user = this.Get(id);
            this.dataContext.Users.Remove(user);
            this.dataContext.SaveChanges();
        }

        public User Get(int id)
        {
            return this.dataContext.Users.SingleOrDefault(u => u.ID == id);
        }

        public void Update(User entity)
        {
            this.dataContext.Entry(entity).State = EntityState.Modified;
            this.dataContext.SaveChanges();
        }

        public User[] List()
        {
            return this.dataContext.Users.ToArray();
        }
    }
}
