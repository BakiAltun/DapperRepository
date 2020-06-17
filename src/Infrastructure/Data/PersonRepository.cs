using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Data;
using ApplicationCore.Interfaces.Data.Library;

namespace Infrastructure.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IRepository<Person> _repository;

        public PersonRepository(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public bool Insert(Person person)
        {
            _repository.Insert(person);

            return person.Id > 0;
        }
    }
}