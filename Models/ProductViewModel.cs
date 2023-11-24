using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAmazon.Models
{
    public class ProductViewModel
    {
        public string ProName { get; set; }
        public int ProID { get; set; }
        public int CatID { get; set; }
        public string ProImage { get; set; }
        public int ProDeID { get; set; }
        public double Price { get; set; }
        public int RemainQuantity { get; set; }
    }
}