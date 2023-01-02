using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRHomeWebApi.Dtos
{
    public class PropertyDto
    { 
        public string Name { get; set; }
        public int SellRent { get; set; }
        public int BHK{get;set;}
        public int PropertyTypeId { get; set; }
        public int FurnishingTypeId { get; set; }
        public double Price { get; set; }
        public double BuiltArea { get; set; }
        public double CarpetArea { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CityId { get; set; }
        public int FloorNo { get; set; }
        public int TotalFloors { get; set; }
        public bool ReadyToMove { get; set; }
        public string MainEntrance { get; set; }
        public int Security { get; set; } = 0;
        public bool Gated { get; set; }
        public int Maintenance { get; set; } = 0;
        public DateTime EstPossessionOn { get; set; }
        public int Age { get; set; } = 0;
        public string Description { get; set; }
        public string Photo { get; set; }
    }
}