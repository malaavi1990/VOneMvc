using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class TraktStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TraktStatusId { get; set; }
        public string TraktStatusName { get; set; }
        public string Tittle { get; set; }

        public virtual ICollection<Trakt> Trakts { get; set; }
    }
}
