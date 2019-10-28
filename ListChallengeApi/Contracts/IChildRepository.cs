using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace Contracts
{
    public interface IChildRepository
    {
        Task<IEnumerable<Child>> GetAllChildAsync();
        Task<IEnumerable<Child>> GetAllChildValuesByFactoryIdAsync(Guid id);
        Task<Child> GetChildByIdAsync(Guid id);
        Task CreateChildAsync(Child child);
        Task CreateChildInBulkAsync(List<Child> childs);
        Task DeleteAllChildAsync(IEnumerable<Child> child);
        Task DeleteChildAsync(Child child);
    }
}