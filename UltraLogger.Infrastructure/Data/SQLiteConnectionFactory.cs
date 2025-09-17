using System.Data.Common;
using System.Data.SQLite;

namespace UltraLogger.Infrastructure.Data;

public class SQLiteConnectionFactory : IDbConnectionFactory
{
    private readonly string _dataSource;

    public SQLiteConnectionFactory(string dataSource)
    {
        _dataSource = dataSource;
    }

    public DbConnection CreateConnection()
    {
        SQLiteConnectionStringBuilder stringBuilder = new SQLiteConnectionStringBuilder();
        stringBuilder.DataSource = _dataSource;
        stringBuilder.ForeignKeys = true;
        stringBuilder.FailIfMissing = true;
        stringBuilder.DateTimeFormat = SQLiteDateFormats.Ticks;
        return new SQLiteConnection(stringBuilder.ToString());
    }
}

