using Wedding.Models;
using Wedding.Repositories.Interfaces;

namespace Wedding.Repositories.Implementations
{
    public class ClientRepository :GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(WeddingContext context) : base(context)
        {

        }
    }
}
