using EticaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Quantity { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }

        public ICollection<OrderProduct> Orders { get; set; }
        public Category Category { get; set; }
    }
}
