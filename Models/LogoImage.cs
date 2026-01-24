using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FR_Groups_websites.Models
{
    [Table("T_LogoImages")]
    public class LogoImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string ImagePath { get; set; } = null!;

    }
}
