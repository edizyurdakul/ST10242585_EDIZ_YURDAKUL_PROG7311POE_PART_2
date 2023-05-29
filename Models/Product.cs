using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ST10242585_EDIZ_YURDAKUL_PROG7311POE_PART_2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
    }
}