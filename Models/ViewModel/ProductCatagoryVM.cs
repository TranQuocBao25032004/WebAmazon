using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAmazon.Models.ViewModel
{
    public class ProductCatagoryVM
    {
        //product detail
        
        public int ProDeID { get; set; }
        public double Price { get; set; }
        public int RemainQuantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<int> ViewQuantity { get; set; }

        [Key]
        //product
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string NameDecription { get; set; }

        //Catagory
        public int CatID { get; set; }
        public string NameCate { get; set; }

        //Supplier
        public int SupID { get; set; }
        public string SupName { get; set; }
        public string Address { get; set; }

        //Color
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string RGB { get; set; }

        public ICollection<DetailProductVM> RelatedProducts { get; set; }
    }
}