using test.Data;

namespace test.Business.Managers
{
    public class ManagerBase
    {
        protected RepositoryManager repositoryManger;

        protected BusinessContext businessContext;

        public ManagerBase(BusinessContext businessContext, RepositoryManager repositoryManger)
        {
            this.repositoryManger = repositoryManger;
            this.businessContext = businessContext;
        }
    }
}
