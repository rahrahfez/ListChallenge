namespace Contracts
{
    public interface IRepositoryWrapper
    {
         IRootRepository Root { get; }
         IFactoryRepository Factory { get; }
         void Save();
    }
}