using Library.Application.Abstractions.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Library.Infrastructure.Data;
public sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
