using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelUserProfiles : BasicModel
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Pro")]
        public string ProId { get; set; }

        public EntProfiles Pro { get; set; }
        public EntUsers User { get; set; }
    }
}
