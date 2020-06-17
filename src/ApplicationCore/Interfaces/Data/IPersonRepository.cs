using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Data
{
    public interface IPersonRepository
    {
        bool Insert(Person entity);
    }
}