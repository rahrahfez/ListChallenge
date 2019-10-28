using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IRootRepository _root;
        private IFactoryRepository _factory;
        private IChildRepository _child;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public IRootRepository Root
        {
            get
            {
                if (_root == null)
                {
                    _root = new RootRepository(_repoContext);
                }
                return _root;
            }
        }
        public IFactoryRepository Factory
        {
            get
            {
                if (_factory == null)
                {
                    _factory = new FactoryRepository(_repoContext);
                }
                return _factory;
            }
        }
        public IChildRepository Child
        {
            get
            {
                if (_child == null)
                {
                    _child = new ChildRepository(_repoContext);
                }
                return _child;
            }
        }
        public void Save() {
            _repoContext.SaveChanges();
        }
    }
}