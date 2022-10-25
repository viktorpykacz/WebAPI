using Microsoft.EntityFrameworkCore;
using WebAPI;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Przychod> Przychody { get; set; }
        public DbSet<Koszt> Koszty { get; set; }
        public DbSet<WebAPI.ZestawienieMiesieczne> ZestawienieMiesieczne { get; set; }
        public DbSet<WebAPI.ZestawienieGodzin> ZestawienieGodzin { get; set; }
        public DbSet<WebAPI.Podatek> Podatek { get; set; }
        public DbSet<WebAPI.Godziny> Godziny { get; set; }
        public DbSet<WebAPI.Kontrakt> Kontrakt { get; set; }


    }
}
