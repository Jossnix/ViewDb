namespace ViewDb;

public static class PgOptions
{
    public const string Host  = "localhost";
    public const string Database = "hw_db";
    public const string Username = "postgres";
    public const string Password = "postgres";    

    public const string ConnectionString = $"Host={Host};Database={Database};Username={Username};Password={Password};";
}