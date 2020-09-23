using System.Linq;
using EfCore.Example.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Example.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionsController : ControllerBase
    {
        private readonly DbContext _context;

        public ConnectionsController([FromServices] DbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _context
                    .Set<Connection>()
                    .Include(x => x.ConnectionInfo)
                    .ToArray());
        }
        
        [HttpPost("mssql")]
        public IActionResult Post(MssqlDto dto)
        {
            _context.Add(new Connection()
            {
                ConnectionInfo = new MssqlConnectionInfo
                {
                    Host = dto.Host,
                    Password = dto.Password,
                    User = dto.User,
                }
            });

            _context.SaveChanges();
            
            return NoContent();
        }
        
        [HttpPost("postgres")]
        public IActionResult Post(PostgresDto dto)
        {
            _context.Add(new Connection()
            {
                ConnectionInfo = new PostgresConnectionInfo
                {
                    Host = dto.Host,
                    Password = dto.Password,
                    Port = dto.Port,
                    User = dto.User,
                }
            });
            
            _context.SaveChanges();

            return NoContent();
        }
        
        [HttpPost("server")]
        public IActionResult Post(ServerDto dto)
        {
            _context.Add(new Connection()
            {
                ConnectionInfo = new ServerConnectionInfo
                {
                    Token = dto.Token
                }
            });
            
            _context.SaveChanges();

            return NoContent();
        }
    }
}