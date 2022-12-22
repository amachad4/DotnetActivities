using System.ComponentModel.DataAnnotations;

namespace Activities.Model
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
