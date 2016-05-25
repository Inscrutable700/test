using System;
using test.Business.Managers;
using test.Data;

namespace test.Business
{
    public class BusinessContext : IDisposable
    {
        private RepositoryManager repositoryManager;

        private UserManager userManager;

        public BusinessContext()
        {
            this.repositoryManager = new RepositoryManager(DataResourceType.MSSql);
        }

        public UserManager UserManager
        {
            get
            {
                if(this.userManager == null)
                {
                    this.userManager = new UserManager(this, this.repositoryManager);
                }

                return this.userManager;
            }
        }

        public void Dispose()
        {
            if (this.repositoryManager != null)
            {
                this.repositoryManager.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}
