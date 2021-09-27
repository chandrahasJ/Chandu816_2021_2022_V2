using System.ComponentModel.DataAnnotations;

namespace BRHomeWebApi.Models
{
    public class User : BaseEntity
    { 
        [Required]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }

        public string Email { get; set; }
        public long Mobile { get; set; }
    }
}