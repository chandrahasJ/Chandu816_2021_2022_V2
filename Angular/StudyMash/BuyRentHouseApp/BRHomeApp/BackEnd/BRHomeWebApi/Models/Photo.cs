using System.ComponentModel.DataAnnotations.Schema;

namespace BRHomeWebApi.Models
{
    [Table("Photos")]
    public class Photo : BaseEntity
    {
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}