namespace WebAPI.Models
{
    public class Godziny
    {
        public int Id { get; set; }
        public DateTime? DataWpisu { get; set; }
        public DateTime? DataPracy { get; set; }
        public string? NazwaProjektu { get; set; }
        public int? IleGodzin { get; set; }
    }
}
