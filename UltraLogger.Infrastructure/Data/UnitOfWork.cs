using Dapper;
using System.Data.Common;
using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbConnection _connection;
    private DbTransaction _transaction;
    private bool _disposed;

    public UnitOfWork(IDbConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.CreateConnection();
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public T? QuerySingleOrDefault<T>(string sql, object? param = null)
    {
        return _connection.QuerySingleOrDefault<T>(sql, param, _transaction);
    }

    public IEnumerable<T> Query<T>(string sql, object? param = null)
    {
        return _connection.Query<T>(sql, param, _transaction);
    }

    public T? ExecuteScalar<T>(string sql, object? param = null)
    {
        return _connection.ExecuteScalar<T>(sql, param, _transaction);
    }

    public int Execute(string sql, object? param)
    {
        return _connection.Execute(sql, param, _transaction);
    }

    internal long GetNewId(string table)
    {
        return ExecuteScalar<long>($"SELECT MAX(Id) + 1 FROM {table}");
    }

    public void SaveChanges()
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().FullName);

        try
        {
            _transaction.Commit();
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
        finally
        {
            _transaction.Dispose();
            _transaction = _connection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _transaction.Dispose();
            _connection.Dispose();
            _disposed = true;
        }
    }
}
