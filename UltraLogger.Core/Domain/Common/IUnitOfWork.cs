namespace UltraLogger.Core.Domain.Common;

public interface IUnitOfWork : IDisposable
{
    void SaveChanges();
}