using System;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IRootRepository
    {
         Task<RootTreeModel> GetRootByIdAsync(Guid id);
         Task CreateRootAsync(RootTreeModel root);
         Task DeleteRootAsync(RootTreeModel root);
    }
}