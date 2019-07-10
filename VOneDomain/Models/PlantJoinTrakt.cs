using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class PlantJoinTrakt
    {
        [Key]
        public long PlantJoinTraktId { get; set; }

        public long TraktId { get; set; }
        [ForeignKey(nameof(TraktId))]
        public virtual Trakt Trakt { get; set; }

        public int PlantId { get; set; }
        [ForeignKey(nameof(PlantId))]
        public virtual Plant Plant { get; set; }
    }
}
