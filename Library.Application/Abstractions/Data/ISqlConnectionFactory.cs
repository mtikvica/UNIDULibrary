using System.Data;

namespace Library.Application.Abstractions.Data;
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
