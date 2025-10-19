namespace Softela.PestScheduler.Infrastructure.Database.Connections
{
    public class DatabaseOptions
    {
        public const string SectionName = "Database";
        public string Server { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Configuration { get; set; }
        public bool EnableSensitiveLogging { get; set; }
    }
}
