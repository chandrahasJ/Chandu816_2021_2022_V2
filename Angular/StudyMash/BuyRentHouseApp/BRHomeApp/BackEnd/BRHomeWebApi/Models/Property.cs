using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BRHomeWebApi.Models
{
    public class Property : BaseEntity
    { 
        public string Name { get; set; }
        public int SellRent { get; set; }
        public int BHK{get;set;}
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }
        public int FurnishingTypeId { get; set; }
        public FurnishingType FurnishingType { get; set; }
        public double Price { get; set; }
        public double BuiltArea { get; set; }
        public double CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloors { get; set; }
        public bool ReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; }
        public bool Gated { get; set; }
        public int Maintenance { get; set; }
        public DateTime EstPossessionOn { get; set; }
        public int Age { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        public ICollection<Photo>  Photos { get; set; }
        public DateTime PostedOn { get; set; } = DateTime.Now;
        [ForeignKey("User")]
        public int PostedBy { get; set; }
        public User User { get; set; }
    }
}