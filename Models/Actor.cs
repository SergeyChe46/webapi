using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    [Index(nameof(FullName), IsUnique = true)]
    public class Actor
    {
        [Key]
        public int ActorId { get; set; }
        [Required]
        public string FullName { get; set; }
        public virtual List<Movie>? Movie { get; set; }
    }
}
