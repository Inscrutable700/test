using test.Data;
using test.Data.Models;

namespace test.Business.Managers
{
    public class UserManager : ManagerBase
    {
        public UserManager(BusinessContext businessContext, RepositoryManager repositoryManager)
            :base(businessContext, repositoryManager)
        {
        }

        public User AddUser(User user)
        {
            return this.repositoryManger.UserRepository.Add(user);
        }

        public User GetUser(int id)
        {
            return this.repositoryManger.UserRepository.Get(id);
        }

        public void UpdateUser(User user)
        {
            this.repositoryManger.UserRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            this.repositoryManger.UserRepository.Delete(id);
        }

        public User[] GetUsers()
        {
            return this.repositoryManger.UserRepository.List();
        }

    }
}
