using System.ComponentModel.DataAnnotations;

namespace BRHomeWebApi.Models
{
    public class FurnishingType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
    }
}