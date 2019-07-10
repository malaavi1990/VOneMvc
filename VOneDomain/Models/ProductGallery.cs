using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class ProductGallery
    {
        [Key]
        public long ProductGalleryId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }

        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
