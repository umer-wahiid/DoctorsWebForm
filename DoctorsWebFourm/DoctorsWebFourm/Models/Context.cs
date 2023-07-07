using Microsoft.EntityFrameworkCore;

namespace DoctorsWebFourm.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> Options) : base(Options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Query> Query { get; set; }
        public DbSet<Reply> Reply { get; set; }
    }
}
