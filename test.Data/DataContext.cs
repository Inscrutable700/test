using System.Data.Entity;
using test.Data.Models;

namespace test.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
