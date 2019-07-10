using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneViewModel
{
    public class TraktViewModels
    {
        [Display(Name = "عنوان تراکت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string TraktTitle { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(800, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Description { get; set; }

        [Display(Name = "توضیح کامل")]
        public string Text { get; set; }

        [Display(Name = "تاریخ شروع نمایش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime FromDate { get; set; }

        [Display(Name = "تاریخ اتمام نمایش")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime ToDate { get; set; }

        public int TraktCategoryId { get; set; }
        public int TraktTypeId { get; set; }
        public int TraktStatusId { get; set; }
        public bool HaveSlider { get; set; }
    }
}
