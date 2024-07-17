using EticaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public int ShopAssistantId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SaleDate { get; set; }

        public OrderProduct OrderProduct { get; set; }
        public ShopAssistant ShopAssistant { get; set; }
        public Customer Customer { get; set; }

    }
}
