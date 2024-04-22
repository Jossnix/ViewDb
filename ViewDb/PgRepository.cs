using Dapper;
using Npgsql;

namespace ViewDb;

public static class PgRepository
{
    public static async Task<IEnumerable<T>> ExecuteAsync<T>(string sql)
    {
        using var connection = new NpgsqlConnection(PgOptions.ConnectionString);
        
        await connection.OpenAsync();

        var rows = await connection.QueryAsync<T>(sql);

        connection.Close();
        
        return rows;
    }  
}