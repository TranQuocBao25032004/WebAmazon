using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAmazon.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {

       

    }
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        [NotMapped]
        public HttpPostedFileBase UploadImage { get; set; }
        ////    //    [NotMapped]
        //    //    public List<ProDetail> RemainProducts { get; set; }

        //    //    [NotMapped]
        //    //    public List<Product> NeedImportProducts { get; set; }

        //        [NotMapped]
        //    //    public List<Product> BestSellerProducts { get; set; }
    }
    [MetadataType(typeof(CatagoryMetadata))]
    public partial class Category
    {

    }
    [MetadataType(typeof(ColorMetadata))]
    public partial class Color
    {

    }
    [MetadataType(typeof(OrderMetadata))]
    public partial class Order
    {

    }
    [MetadataType(typeof(SupplierMetadata))]
    public partial class Supplier
    {

    }
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        [NotMapped]
        [DisplayName("Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Nhập lại mật khẩu !")]
        [Compare("CusPassword")]
        public string Repass { get; set; }
    }
    [MetadataType(typeof(ProDetailMetadata))]
    public partial class ProDetail
    {

    }
}