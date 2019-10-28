using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IRootRepository
    {
         Task<Root> GetRootByIdAsync(Guid id);
         Task<IEnumerable<Root>> GetRootsAsync();
         Task CreateRootAsync(Root root);
         Task DeleteRootAsync(Root root);
    }
}