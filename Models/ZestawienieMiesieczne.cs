namespace WebAPI.Models
{
    public class ZestawienieMiesieczne
    {
        public int Id { get; set; }
        public DateTime? DataWpisu { get; set; }
        public int? Rok { get; set; }
        public int? Miesiac { get; set; }
        public decimal? KosztyBiuro { get; set; }
        public decimal? KosztyAuto { get; set; }
        public decimal? KosztyLacznie { get; set; }
        public decimal? PrzychodyLacznie { get; set; }
        public decimal? VatLacznie { get; set; }

    }
}
