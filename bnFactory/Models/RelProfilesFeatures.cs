using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelProfilesFeatures : BasicModel
    {
        [ForeignKey("Pro")]
        public string ProId { get; set; }
        [ForeignKey("Fea")]
        public string FeaId { get; set; }
        [Required]
        public int Permission { get; set; }

        public EntFeatures Fea { get; set; }
        public EntProfiles Pro { get; set; }
    }
}
