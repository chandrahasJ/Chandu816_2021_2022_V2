using System;
using System.ComponentModel.DataAnnotations;

namespace BRHomeWebApi.Models
{
    public class City : BaseEntity
    { 
        [Required(ErrorMessage = "Name is mandatory field.")]
        [StringLength(50, MinimumLength = 2 )]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numeric field is not allowed.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country is mandatory field.")]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numeric field is not allowed.")]
        public string CountryName { get; set; }
    }
}