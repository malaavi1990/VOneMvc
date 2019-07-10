using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VOneDomain.Models
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }
        public string SiteTitle { get; set; }
        public string IconUrl { get; set; }
        public string CopyRight { get; set; }
        public string KeyWord { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
    }
}
