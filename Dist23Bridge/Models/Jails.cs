using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dist23Bridge.Models
{
    public class Jails
    {
        [Key]
        public int jail_id { get; set; }
        public string JailName { get; set; }
        public string JailAddress { get; set; }
        public string JailContact { get; set; }
        public string JailContPhone { get; set; }
        public string JailContEmail { get; set; }
    }
}