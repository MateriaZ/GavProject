using GavResortsTest.Models;
using Microsoft.EntityFrameworkCore;

namespace GavResortsTest.DataBase
{
    public class Context : DbContext
    {
        protected readonly IConfiguration Configuration;
        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite(Configuration.GetConnectionString("SQLiteDatabase"))
                .UseLazyLoadingProxies();
        }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Contact> Contatos { get; set; }


    }
}
