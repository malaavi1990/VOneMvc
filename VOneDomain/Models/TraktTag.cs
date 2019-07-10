using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class TraktTag
    {
        [Key]
        public long TraktTagId { get; set; }
        public string TagTitle { get; set; }
        public DateTime CreateDate { get; set; }

        public long TraktId { get; set; }
        [ForeignKey(nameof(TraktId))]
        public virtual Trakt Trakt { get; set; }

    }
}
