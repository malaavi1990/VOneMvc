using System.Collections.Generic;

namespace VOneDomain.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Title { get; set; }

        public virtual ICollection<AccessLevel> AccessLevels{ get; set; }
    }
}
