namespace EfCore.Example.Domain
{
    public class Connection: EntityBase
    {
        public ConnectionInfo ConnectionInfo { get; set; }
    }

    public abstract class ConnectionInfo : EntityBase
    {
        public ConnectionInfo()
        {
            Type = GetType().Name;
        }
        
        public string Type { get; protected set; }
    }

    public class MssqlConnectionInfo : ConnectionInfo
    {
        public string Host { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
    
    public class PostgresConnectionInfo : ConnectionInfo
    {
        public string Host { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
        
        public string Port { get; set; }
    }
    
    public class ServerConnectionInfo : ConnectionInfo
    {
        public string Token { get; set; }
    }
}