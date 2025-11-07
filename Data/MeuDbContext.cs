using Aiury.Models;
using Microsoft.EntityFrameworkCore;

namespace Aiury.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Estados> Estados { get; set; }
        public DbSet<Cidades> Cidades { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Ajudantes> Ajudantes { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Mensagem> Mensagens { get; set; }
    }
}
