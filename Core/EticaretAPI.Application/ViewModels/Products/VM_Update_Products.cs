﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Application.ViewModels.Products
{
    public class VM_Update_Products
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int Quantity { get; set; }
        public string Feature1 { get; set; }
        public string Feature2 { get; set; }
    }
}
