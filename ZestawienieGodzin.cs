namespace WebAPI
{
    public class ZestawienieGodzin
    {
        public int Id { get; set; }
        public DateTime? DataWpisu { get; set; }
        public int? Rok { get; set; }
        public int? Miesiac { get; set; }
        public string? NazwaProjektu { get; set; }
        public int? IleGodzin { get; set; }

    }
}
