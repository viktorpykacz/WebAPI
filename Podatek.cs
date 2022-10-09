namespace WebAPI
{
    public class Podatek
    {
        public int Id { get; set; }
        public DateTime? DataWpisu { get; set; }
        public decimal? VatDoOdliczenia { get; set; }
        public decimal? PitDoZaplaty { get; set; }
        public decimal? VatDoZaplaty { get; set; }
        public decimal? ZusDoZaplaty { get; set; }

    }
}
