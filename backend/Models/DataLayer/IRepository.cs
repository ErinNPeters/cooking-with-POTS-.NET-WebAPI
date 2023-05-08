namespace backend.Models.DataLayer
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
