using Jesstw.Model;
using Microsoft.EntityFrameworkCore;

namespace Jesstw.Context
{
    public class ServerContext : DbContext
    {
        public ServerContext(DbContextOptions<ServerContext> options) : base (options){}
        
        public DbSet<User> Users {get; set;}
    }
}
