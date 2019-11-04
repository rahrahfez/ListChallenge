using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RootRepository : RepositoryBase<Root>, IRootRepository
    {
        public RootRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<Root>> GetRootsAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task<Root> GetRootByIdAsync(Guid id)
        {
            return await FindByCondition(root => root.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task CreateRootAsync(Root root)
        {
            Create(root);
            await SaveAsync();
        }
        public async Task DeleteRootAsync(Root root)
        {
            Delete(root);
            await SaveAsync();
        }
    }
}
