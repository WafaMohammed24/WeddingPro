
using Wedding.Models;
using Wedding.Repositories.Interfaces;

namespace Wedding.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeddingContext context;

        public UnitOfWork(WeddingContext context)
        {
            this.context = context;
        }
        public int SaveChanges()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
