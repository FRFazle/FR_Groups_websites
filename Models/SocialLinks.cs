using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FR_Groups_websites.Models
{
    [Owned]
    public class SocialLinks
    {
        [MaxLength(255)]
        [Url]
        public string Facebook { get; set; } = null!;
        [MaxLength(255)]
        [Url]
        public string LinkedIn { get; set; } = null!;
        [MaxLength(255)]
        [Url]
        public string Twitter { get; set; } = null!;
        [MaxLength(255)]
        [Url]
        public string YouTube { get; set; } = null!;
    }
}
