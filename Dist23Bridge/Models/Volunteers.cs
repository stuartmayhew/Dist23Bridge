using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Dist23Bridge.Models
{
    public class Volunteers
    {
        [Key]
        public int vol_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}