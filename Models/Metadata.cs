using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WebAmazon.Models
{

    public class UserMetadata
    {
        [Required(ErrorMessage = "Tên Người Dùng bắt buộc!")]
        [StringLength(30, MinimumLength = 5)]
        [DisplayName("Tên Người Dùng")]
        //[RegularExpression("\r\n ^[a-zA-Z0-9]([._-](?![._-])|[a-zA-Z0-9]){3,18}[a-zA-Z0-9]$\r\n")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Mật khẩu bắt buộc!")]
        [DisplayName("Mật khẩu")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Mật khẩu không dài quá 30 ký tự")]
        public string Password { get; set; }
        [StringLength(7, ErrorMessage = "Tên sản phẩm không dài quá 7 ký tự")]
        [Required(ErrorMessage="Vị trí của Người Dùng bắt buộc!")]
        [DisplayName("Vị trí của Người Dùng")]
        public string Role { get; set; }
    }
    public class ProductMetadata
    {
        [Display(Name = "Mã sản phẩm")]
        public int ProID { get; set; }
        [StringLength(30,ErrorMessage ="Tên sản phẩm không dài quá 30 ký tự")]
        [Required(ErrorMessage = "Phải nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string ProName { get; set; }
        [Display(Name = "Chủng loại sản phẩm")]
        public int CatID { get; set; }
        //[Display(Name = "Đường dẫn ảnh sản phẩm")]
        //[DefaultValue("~/Content/image/iconheadphone.png")]
        [Display(Name ="Ảnh")]
        public string ProImage { get; set; }
        [Display(Name = "Mô tả")]
       
        public string NameDecription { get; set; }
        [Display(Name = "Ngày Tạo")]
        public System.DateTime CreatedDate { get; set; }
    }
    public class CatagoryMetadata
    {
        [Required(ErrorMessage ="Mã Sản Phẩm Bắt Buộc ")]
        [Display(Name = "Mã Sản Phẩm")]
        public int CatID { get; set; }
        [StringLength(12, ErrorMessage = "Tên Hãng không dài quá 12 ký tự")]
        [Display(Name = ("Tên Sản Phẩm"))]
        public string NameCate
        {
            get; set;
        }
    }
    public class ColorMetadata
    {
        [Display(Name="Mã Màu")]
        public int ColorID { get; set; }
        [Display(Name="Tên màu")]
        public string ColorName { get; set; }
        [Display(Name="RGB")]
        public string RGB { get; set; }
    }
    public class OrderMetadata
    {
        [Display(Name = "Mã đơn hàng ")]
        public int OrderID { get; set; }
        [Display(Name = "Ngày đặt hàng ")]
        public Nullable<System.DateTime> OrderDate { get; set; }
        [StringLength(12, ErrorMessage = "Tên số điện thoại không dài quá 12 ký tự")]
        [Display(Name = "Số điện thoại ")]
        public string CusPhone { get; set; }
        [StringLength(30, ErrorMessage = "Tên số địa chỉ không dài quá 30 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string AddressDeliverry { get; set; }
        [Display(Name = "Tổng tiền")]
        public Nullable<double> TotalValue { get; set; }
    }
    public class SupplierMetadata
    {
        [Display(Name = "Mã nhà cung cấp ")]
        public int SupID { get; set; }
        [StringLength(20, ErrorMessage = "Tên nhà cung cấp không dài quá 20 ký tự")]
        [Display(Name = "Tên nhà cung cấp ")]
        public string SupName { get; set; }
        [StringLength(30, ErrorMessage = "Tên số địa chỉ không dài quá 30 ký tự")]
        [Display(Name = "Địa chỉ ")]
        public string Address { get; set; }
    }
    public class CustomerMetadata {
        [StringLength(12, ErrorMessage = "Tên số điện thoại không dài quá 12 ký tự")]
        [Display(Name = "Số Điện Thoại")]
        public string CusPhone { get; set; }
        [StringLength(30, ErrorMessage = "Mật khẩu không dài quá 30 ký tự")]
        [Display(Name = "mật khẩu")]
        public string CusPassword { get; set; }
        [Display(Name = "Tên khách hàng")]

        public string CusName { get; set; }
        [Display(Name = "Email")]
        public string CusEmail { get; set; }
    }
    public class ProDetailMetadata {
        public int ProDeID { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public int ProID { get; set; }
        [Display(Name = "Nhà cung cấp ")]
        public int SupID { get; set; }
        [Display(Name = "Màu")]
        public int ColorID { get; set; }
        [Display(Name = "Đơn Giắ")]
        public double Price { get; set; }
        [Display(Name = "Số lượng kho ")]
        public int RemainQuantity { get; set; }
        [Display(Name = "Đã bán")]
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        [Display(Name = "Lượt xem")]
        public Nullable<int> ViewQuantity { get; set; }
    }

}