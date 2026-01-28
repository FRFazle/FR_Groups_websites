using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FR_Groups_websites.Models
{
    [Table("T_Contacts")]
    public class Contact
    {
        [Key]  
        public int Id { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;

        public SocialLinks SocialLinks { get; set; } = new();
    }
}
