using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOneDomain.Models
{
    public class Trakt
    {
        [Key]
        public long TraktId { get; set; }
        public string TraktTitle { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int VisitCount { get; set; }
        public bool HaveSlider { get; set; }
        public string SliderImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public string Text { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int TraktCategoryId { get; set; }
        [ForeignKey(nameof(TraktCategoryId))]
        public virtual TraktCategory TraktCategory { get; set; }

        public int TraktTypeId { get; set; }
        [ForeignKey(nameof(TraktTypeId))]
        public virtual TraktType TraktType { get; set; }

        public int TraktStatusId { get; set; }
        [ForeignKey(nameof(TraktStatusId))]
        public virtual TraktStatus TraktStatus { get; set; }

        public virtual ICollection<TraktTag> TraktTags { get; set; }
        public virtual ICollection<PlantJoinTrakt> PlantJoinTrakts { get; set; }
    }
}
