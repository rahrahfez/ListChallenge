using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ChildRepository : RepositoryBase<Child>, IChildRepository
    {
        public ChildRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
        public async Task<Child> GetChildByIdAsync(Guid id)
        {
            return await FindByCondition(child => child.Id.Equals(id))
                .SingleOrDefaultAsync();
        }
        public async Task<IEnumerable<Child>> GetAllChildValuesByFactoryIdAsync(Guid id)
        {
            return await FindAll().Where(child => child.FactoryId.Equals(id))
                .ToListAsync();
        }
        public async Task<IEnumerable<Child>> GetAllChildAsync()
        {
            return await FindAll().ToListAsync();
        }
        public async Task CreateChildInBulkAsync(List<Child> childs)
        {
            foreach (var child in childs)
            {
                Create(child);
            }
            await SaveAsync();
        }
        public async Task CreateChildAsync(Child child)
        {
            Create(child);
            await SaveAsync();
        }
        public async Task DeleteChildAsync(Child child)
        {
            Delete(child);
            await SaveAsync();
        }
    }
}