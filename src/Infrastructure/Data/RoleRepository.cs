using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Data.Library;

namespace Infrastructure.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IRepository<Role> _repository;

        public RoleRepository(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public bool Insert(Role role)
        {
            _repository.Insert(role);

            return role.Id > 0;
        }
    }
}