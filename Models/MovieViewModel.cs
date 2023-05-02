namespace webapi.Models
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string? Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Director { get; set; }
    }
}
