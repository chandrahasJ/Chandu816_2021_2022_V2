using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace onlineshop_webapi.Models
{
    public class Product : BaseEntity
    {
        [ForeignKey(nameof(ProductType))]
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
    }
}