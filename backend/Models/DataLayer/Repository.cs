using Microsoft.EntityFrameworkCore;

namespace backend.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected RecipesContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public Repository(RecipesContext ctx)
        {
            context = ctx;
            dbset = context.Set<T>();
        }

        public virtual T? Get(int id) => dbset.Find(id);
        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Update(T entity) => dbset.Update(entity);
        public virtual void Delete(T entity) => dbset.Remove(entity);
    }
}
