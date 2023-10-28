using Microsoft.EntityFrameworkCore;

namespace Lection15Program3.DB
{
	public class TestDbContext:DbContext
	{
        public TestDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}

