using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class TraktCategory
    {
        [Key]
        public int TraktCategoryId { get; set; }

        [Display(Name = "عنوان دسته")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "{0} باید بین {1} و {2} کاراکتر باشد")]
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int? ParentId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Trakt> Trakts { get; set; }
    }
}
