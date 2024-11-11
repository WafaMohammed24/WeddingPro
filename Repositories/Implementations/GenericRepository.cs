using Microsoft.EntityFrameworkCore;
using Wedding.Models;
using Wedding.Repositories.Interfaces;

namespace Wedding.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly WeddingContext context;

        public GenericRepository(WeddingContext context)
        {
            this.context = context;
        }
        public T Add(T entity)
        {
            try
            {
                var res = context.Add(entity);

                return res.Entity;

            }
            catch (Exception ex)
            {
                //throw ex;
                Console.WriteLine(ex);
                return default;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                var res = context.Remove(entity);
                if (res.State == EntityState.Deleted)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T Update(T entity)
        {
            try
            {
                var res = context.Update(entity);
                if (res.State == EntityState.Modified)
                {
                    return res.Entity;
                }
                return default;
            }
            catch (Exception ex)
            {
                return default;
            }
        }
    }
}
