using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IFactoryRepository
    {
        Task<IEnumerable<Factory>> GetAllFactoriesAsync();
        Task<IEnumerable<Factory>> GetAllFactoriesByRootId(Guid id);
        Task<Factory> GetFactoryByIdAsync(Guid id);
        Task CreateFactoryAsync(Factory factory);
        Task UpdateFactoryAsync(Factory factory);
        Task DeleteFactoryAsync(Factory factory);
    }
}