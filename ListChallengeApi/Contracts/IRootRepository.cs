using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IRootRepository
    {
         Task<Root> GetRootByIdAsync(Guid id);
         Task CreateRootAsync(Root root);
         Task DeleteRootAsync(Root root);
    }
}