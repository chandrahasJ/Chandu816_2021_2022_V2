using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineshop_webapi.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdatedOn { get; set; } = DateTime.Now;
        public int LastUpdatedBy { get; set; }
    }
}