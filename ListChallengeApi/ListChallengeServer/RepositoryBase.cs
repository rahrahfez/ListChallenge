using System;

namespace Repository
{
    public class RepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

    }
}
