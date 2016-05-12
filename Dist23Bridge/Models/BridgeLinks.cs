using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Dist23Bridge.Models
{
    public class BridgeLinks
    {
        [Key]
        public int link_id { get; set; }
        public int? vol_id { get; set; }
        public int? bridge_id { get; set; }
        public DateTime? DateAssign { get; set; }
        public DateTime? FirstLetterSent { get; set; }
        public DateTime? FirstResponse { get; set; }
        public DateTime? FirstVisit { get; set; }
        public DateTime? FirstMeeting { get; set; }
        [NotMapped]
        public string BridgerName { get; set; }
        [NotMapped]
        public string VolName { get; set; }

    }
}