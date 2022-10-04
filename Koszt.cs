namespace WebAPI
{
    public class Koszt
    {
        public long Id { get; set; }
        public DateTime? DataWystawieniaFaktury { get; set; }
        public string? NumerFaktury { get; set; }
        public string? NipFirmy { get; set; }
        public string? OpisKosztu { get; set; }
        public string? RodzajKosztu { get; set; }
        public decimal? WartoscNetto { get; set; }
        public decimal? WartoscVat { get; set; }
        public decimal? WartoscBrutto { get; set; }

    }
}
