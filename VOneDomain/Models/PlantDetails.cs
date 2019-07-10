using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class PlantDetails
    {
        [Key]
        public int PlantDetailsId { get; set; }
        public string ShiftTime { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string LatLocation { get; set; }
        public string LongLocation { get; set; }

        public int PlantId { get; set; }
        [ForeignKey(nameof(PlantId))]
        public virtual Plant Plant { get; set; }
    }
}
