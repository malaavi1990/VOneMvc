using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VOneViewModels
{
    public class UserViewModels
    {

        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "لطفا {0} را بدرستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "آدرس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "شماره موبایل")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string MobileNumber { get; set; }
        public int RoleId { get; set; }

    }

    public class EditUserViewModels
    {
        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "لطفا {0} را بدرستی وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "آدرس")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(500, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Address { get; set; }

        [Display(Name = "شماره موبایل")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string MobileNumber { get; set; }
        public int RoleId { get; set; }

    }
}
