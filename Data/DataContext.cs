using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Przychod> Przychody { get; set; }
        public DbSet<Koszt> Koszty { get; set; }

    }
}
