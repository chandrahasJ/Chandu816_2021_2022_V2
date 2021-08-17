using System;

namespace BRHomeWebApi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LastUpdateOn { get; set; }
    }
}