namespace Wedding.Repositories.Interfaces
{
    public interface IRepositoryManager
    {
        IClientRepository ClientRepository { get; }
        IUnitOfWork unitOfWork { get; }
    }
}
