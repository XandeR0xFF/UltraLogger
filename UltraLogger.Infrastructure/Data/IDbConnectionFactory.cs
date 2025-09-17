using System.Data.Common;

namespace UltraLogger.Infrastructure.Data
{
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
