using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAmazon.Models.ViewModel
{
    
    public class ReStock
    {
        [Key]
        public int ProDeID { get; set; }
        public int RemainQuantity { get; set; }
        //products
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string NameDecription { get; set; }
       
    }
}