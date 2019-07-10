using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public DateTime CreateDate { get; set; }
        public string ImageUrl { get; set; }

        public int PlantTypeId { get; set; }
        [ForeignKey(nameof(PlantTypeId))]
        public PlantType PlantType { get; set; }

        public int PlantStatusId { get; set; }
        [ForeignKey(nameof(PlantStatusId))]
        public virtual PlantStatus PlantStatus { get; set; }

        public virtual ICollection<PlantDetails> PlantDetails { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<PlantJoinTrakt> PlantJoinTrakts { get; set; }
    }
}
