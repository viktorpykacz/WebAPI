using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
#pragma warning disable CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
#pragma warning restore CS8618 // Pole niedopuszczające wartości null musi zawierać wartość inną niż null podczas kończenia działania konstruktora. Rozważ zadeklarowanie pola jako dopuszczającego wartość null.
        public DbSet<Przychod> Przychody { get; set; }
        public DbSet<Koszt> Koszty { get; set; }
        public DbSet<ZestawienieMiesieczne> ZestawienieMiesieczne { get; set; }
        public DbSet<ZestawienieGodzin> ZestawienieGodzin { get; set; }
        public DbSet<Podatek> Podatek { get; set; }
        public DbSet<Godziny> Godziny { get; set; }
        public DbSet<Kontrakt> Kontrakt { get; set; }


    }
}
