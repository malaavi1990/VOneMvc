using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOneDomain.Models
{
    public class TraktType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TraktTypeId { get; set; }
        public string TraktTypeName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Trakt> Trakts { get; set; }
    }
}
