using Wedding.Repositories.Interfaces;

namespace Wedding.Repositories.Implementations
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IClientRepository clientRepository;
        private readonly IUnitOfWork unitOfWork;

        public RepositoryManager(
            IClientRepository ClientRepository,
            IUnitOfWork unitOfWork)
        {
          
            clientRepository = ClientRepository;
            this.unitOfWork = unitOfWork;
        }

        IClientRepository IRepositoryManager.ClientRepository => clientRepository;

        IUnitOfWork IRepositoryManager.unitOfWork => unitOfWork;
    }
}
