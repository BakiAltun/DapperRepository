using ApplicationCore.Interfaces.Data.Library;
using Dapper.Contrib.Extensions;

namespace Infrastructure.Data.Library
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWorkConnection _unitOfWork;

        public Repository(IUnitOfWorkConnection unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Insert(T entity)
        {
            _unitOfWork.Open();
            _unitOfWork.Connection.Insert(entity, _unitOfWork.Transaction);
            _unitOfWork.Close();
        }

        public void Update(T entity)
        {
            _unitOfWork.Open();
            _unitOfWork.Connection.Update(entity, _unitOfWork.Transaction);
            _unitOfWork.Close();
        }

        public void Delete(T entity)
        {
            _unitOfWork.Open();
            _unitOfWork.Connection.Delete(entity, _unitOfWork.Transaction);
            _unitOfWork.Close();
        }
    }
}