using System.ComponentModel.DataAnnotations;

namespace BRHomeWebApi.Models
{
    public class PropertyType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}