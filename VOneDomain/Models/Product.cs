  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VOneDomain.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageUrl { get; set; }
        public bool HaveSlider { get; set; }
        public string SliderImageUrl { get; set; }
        public string Price { get; set; }
        public bool IsDeleted { get; set; }
        public int VisitCount { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int ProductCategoryId { get; set; }
        [ForeignKey(nameof(ProductCategoryId))]
        public virtual ProductCategory ProductCategory { get; set; }

        public int ProductStatusId { get; set; }
        [ForeignKey(nameof(ProductStatusId))]
        public virtual ProductStatus ProductStatus { get; set; }

        public virtual ICollection<ProductGallery> ProductGalleries { get; set; }
        public virtual ICollection<ProductTag> ProductTags { get; set; }
    }
}
