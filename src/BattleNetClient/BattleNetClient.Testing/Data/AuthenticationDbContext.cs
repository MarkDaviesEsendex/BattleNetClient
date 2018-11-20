using BattleNetClient.Testing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BattleNetClient.Testing.Data
{
    public class AuthenticationDbContext : DbContext
    {
        public DbSet<ClientInfo> ClientInfo { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public AuthenticationDbContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }
}