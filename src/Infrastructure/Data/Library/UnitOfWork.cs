using System.Data; 
using ApplicationCore.Interfaces.Data.Library;

namespace Infrastructure.Data.Library
{
    public class UnitOfWork : IUnitOfWork, IUnitOfWorkConnection
    {
        public IDbConnection _connection;
        public IDbConnection Connection => _connection;

        private IDbTransaction _transaction;
        public IDbTransaction Transaction => _transaction;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Open()
        {
            if (_connection.State == ConnectionState.Open)
                return;

            _connection.Open();
        }

        public void Close()
        {
            if (_connection.State == ConnectionState.Closed)
                return;

            if (_transaction != null)
                return;

            _connection.Close();
        }

        public void Begin()
        {
            Open();
            _transaction = _connection.BeginTransaction(); 
        }

        public void Commit()
        {
            _transaction.Commit();
            Close();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Close();
        }
    }
}