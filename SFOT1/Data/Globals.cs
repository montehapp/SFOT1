namespace SFOT1.Data
{
    public class Globals
    {
        private static string? _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_connectionString)) return _connectionString;

                var builder = WebApplication.CreateBuilder();
                _connectionString = builder.Configuration.GetConnectionString("SFOAPIContext");

                return _connectionString;
            }

        }
    }
}
