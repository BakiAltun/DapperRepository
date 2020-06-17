using System.Data;

namespace ApplicationCore.Interfaces.Data.Library
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void Rollback();
    }

    public interface IUnitOfWorkConnection
    {
        void Open();
        void Close();
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}