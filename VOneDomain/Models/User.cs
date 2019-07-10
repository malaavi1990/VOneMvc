using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VOneDomain.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLogin { get; set; }
        public int FaildLoginCount { get; set; }
        public string ActiveCode { get; set; }
        public bool EmailConfirm { get; set; }
        public string MobileNumber { get; set; }
        public bool MobileConfirm { get; set; }
        public bool IsLock { get; set; }
        public bool IsDeleted { get; set; }
        public string ProfileImage { get; set; }

        public int PlantId { get; set; }
        [ForeignKey(nameof(PlantId))]
        public Plant Plant { get; set; }

        public int AccessLevelId { get; set; }
        [ForeignKey(nameof(AccessLevelId))]
        public AccessLevel AccessLevel { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
