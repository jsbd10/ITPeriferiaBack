namespace Backend.Helpers.Abstract
{
    public abstract class ConnectionManager
    {
        public string DbConnection { get; set; }

        public ConnectionManager()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json",optional:false).Build();
            DbConnection = configuration["DbConnection:main"];
        }
    }
}
