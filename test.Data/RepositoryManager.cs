using System;
using Ninject;
using test.Data.Repositories;

namespace test.Data
{
    public class RepositoryManager : IDisposable
    {
        private DataContext dataContext;

        private IUserRepository userRepository;

        private IKernel ninjectKernel;

        public RepositoryManager(DataResourceType resourceType)
        {
            this.dataContext = new DataContext();
            this.ninjectKernel = new StandardKernel();
            switch (resourceType)
            {
                case DataResourceType.MSSql:
                    this.BindRepositoriesMSSql();
                    break;

                case DataResourceType.MongoDb:
                    this.BindRepositoriesMongoDb();
                    break;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = this.ninjectKernel.Get<IUserRepository>();
                }

                return this.userRepository;
            }
        }

        public void BindRepositoriesMSSql()
        {
            ninjectKernel.Bind<IUserRepository>()
                .To<UserRepositoryMSSql>()
                .WithConstructorArgument("dataContext", this.dataContext);
        }

        public void BindRepositoriesMongoDb()
        {
            ninjectKernel.Bind<IUserRepository>()
                .To<UserRepositoryMongo>()
                .WithConstructorArgument("dataContext", this.dataContext);
        }

        public void Dispose()
        {
            if (this.dataContext != null)
            {
                this.dataContext.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
