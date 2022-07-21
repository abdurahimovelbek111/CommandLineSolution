using System.ComponentModel.DataAnnotations;
namespace CommandLine.Models
{
    public class Command
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string  HowTo { get; set; }
        [Required]
        public string  Platform { get; set; }
        [Required]
        public string  CommmandLine { get; set; }
    }
}
