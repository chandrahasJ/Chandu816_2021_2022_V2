using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BRHomeWebApi.Dtos
{
    public class PropertyListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SellRent { get; set; }
        public int BHK{get;set;}
        public string PropertyType { get; set; }
        public string FurnishingType { get; set; }
        public double Price { get; set; }
        public double BuiltArea { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public bool ReadyToMove { get; set; }
    }
}