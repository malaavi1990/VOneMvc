using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace VOneDomain.Models
{
    public class PlantType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlantTypeId { get; set; }
        public string PlantTypeName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Plant> Plants { get; set; }
    }
}
