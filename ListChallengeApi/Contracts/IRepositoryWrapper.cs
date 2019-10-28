namespace Contracts
{
    public interface IRepositoryWrapper
    {
         IRootRepository Root { get; }
         IFactoryRepository Factory { get; }
         IChildRepository Child { get; }
         void Save();
    }
}