using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebAmazon.Models;

namespace WebAmazon.Models
{
    public class AdminUser
    {
  

        [Required(ErrorMessage ="Name is not empty")]
        [StringLength(50,MinimumLength =5)]
        [Display(Name ="Tên User")]
        public string NameUser { get; set; }

        [DisplayName("Nhập mật khẩu")]
        [Required(ErrorMessage ="Pass not empty")]
        [DataType(DataType.Password)]
        public string PasswordUser { get; set; }

        [NotMapped]
        [Compare("PasswordUser")]
        [DisplayName("Nhập lại mật khẩu")]
        public string ConfirmPass { get; set; }
        [NotMapped]
        public string ErrorLogin { get; set; }



    }
}