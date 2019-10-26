using System;
using System.Threading.Tasks;
using Entities;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RootRepository : RepositoryBase<RootTreeModel>, IRootRepository
    {
        public RootRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
        public async Task<RootTreeModel> GetRootByIdAsync(Guid id)
        {
            return await FindByCondition(root => root.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task CreateRootAsync(RootTreeModel root)
        {
            Create(root);
            await SaveAsync();
        }
        public async Task DeleteRootAsync(RootTreeModel root)
        {
            Delete(root);
            await SaveAsync();
        }
    }
}
