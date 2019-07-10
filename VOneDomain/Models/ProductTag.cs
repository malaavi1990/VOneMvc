using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VOneDomain.Models
{
    public class ProductTag
    {
        [Key]
        public long ProductTagId { get; set; }
        public string TagTitle { get; set; }
        public DateTime CreateDate { get; set; }

        public long ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
