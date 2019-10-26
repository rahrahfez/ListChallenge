namespace Contracts
{
    public interface IRepositoryWrapper
    {
         IRootRepository Root { get; }
         void Save();
    }
}