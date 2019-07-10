using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VOneViewModels
{
    public class ProductViewModels
    {
        [Display(Name = "عنوان محصول")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(800, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Description { get; set; }

        [Display(Name = "توضیح کامل")]
        public string Text { get; set; }

        [Display(Name = "قیمت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(25, MinimumLength = 1, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Price { get; set; }

        public int CategoryId { get; set; }
        public bool HaveSlider { get; set; }
    }
}
