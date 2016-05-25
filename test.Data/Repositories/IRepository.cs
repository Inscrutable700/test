namespace test.Data.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Get(int id);
        void Update(T entity);
        void Delete(int id);
        T[] List();
    }
}
