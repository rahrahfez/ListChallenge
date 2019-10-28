using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
  public class FactoryRepository : RepositoryBase<Factory>,IFactoryRepository
  {
    public FactoryRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
    {

    }
    public async Task CreateFactoryAsync(Factory factory)
    {
      Create(factory);
      await SaveAsync();
    }
    public async Task UpdateFactoryAsync(Factory factory)
    {
      Update(factory);
      await SaveAsync();
    }
    public async Task DeleteFactoryAsync(Factory factory)
    {
      Delete(factory);
      await SaveAsync();
    }
    public async Task<IEnumerable<Factory>> GetAllFactoriesAsync()
    {
      return await FindAll().ToListAsync();
    }
    public async Task<IEnumerable<Factory>> GetAllFactoriesByRootId(Guid id)
    {
      return await FindAll().Where(factory => factory.RootId.Equals(id))
        .ToListAsync();
    }
    public async Task<Factory> GetFactoryByIdAsync(Guid id)
    {
      return await FindByCondition(factory => factory.Id.Equals(id))
        .SingleOrDefaultAsync();
    }
  }
}