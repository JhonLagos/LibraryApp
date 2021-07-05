using LibraryAppBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppBackend.Repository
{
    public class LibraryAppContext : DbContext
    {
        public LibraryAppContext(DbContextOptions options)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
