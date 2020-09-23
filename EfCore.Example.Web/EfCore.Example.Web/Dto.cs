namespace EfCore.Example.Web
{
    public class MssqlDto
    {
        public string Host { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
    
    public class PostgresDto
    {
        public string Host { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
        
        public string Port { get; set; }
    }
    
    public class ServerDto
    {
        public string Token { get; set; }
    }
}