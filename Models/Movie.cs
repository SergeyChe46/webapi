using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Director { get; set; }        
        public virtual List<Actor?> Actors { get; set; }
    }
}
