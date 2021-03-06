﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dist23Bridge.Models
{
    public class Bridgers
    {
        [Key]
        public int bridge_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string InmateID { get; set; }
        public int? jail_id { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [NotMapped]
        public string JailName { get; set; }
    }
}