using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntFeatures : BasicModel
    {
        public EntFeatures()
        {
            RelProfilesFeatures = new HashSet<RelProfilesFeatures>();
        }

        [Key]
        public string FeaId { get; set; }
        [Required]
        public string FeaName { get; set; }
        public string FeaParent { get; set; }
        public string FeaController { get; set; }
        [Required]
        public bool ShouldShow { get; set; }

        public ICollection<RelProfilesFeatures> RelProfilesFeatures { get; set; }
    }
}
