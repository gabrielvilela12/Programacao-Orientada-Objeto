namespace Sistema_Bancário_Simples.Domain.Data.Connection
{
    internal class DbConnection
    {
        public static string GetConnectionString()
        {
            string password = Environment.GetEnvironmentVariable("DBPassword");

            return $"Host=localhost;Port=5432;Database=SistemaBanco;Username=postgres;Password={password};";
        }


    }
}
