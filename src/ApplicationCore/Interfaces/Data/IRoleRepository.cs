using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Data
{
    public interface IRoleRepository
    {
        bool Insert(Role entity); 
    }
}