using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IFactoryRepository
    {
        Task<IEnumerable<Factory>> GetAllFactoriesAsync();
        Task<Factory> GetFactoryByIdAsync(Guid id);
        Task CreateFactoryAsync(Factory factory);
        Task DeleteFactoryAsync(Factory factory);
    }
}