namespace WebAPI
{
    public class Przychod
    {
        public long Id { get; set; }
        public DateTime? DataWystawieniaFaktury { get; set; }
        public string? NumerFaktury { get; set; }
        public string? NipFirmy { get; set; }
        public string? OpisFaktury { get; set; }
        public decimal? WartoscNetto { get; set; }
        public decimal? WartoscVat { get; set; }
        public decimal? WartoscBrutto { get; set; }

    }
}
