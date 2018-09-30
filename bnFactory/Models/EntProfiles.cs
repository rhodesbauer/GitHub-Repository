using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntProfiles : BasicModel
    {
        public EntProfiles()
        {
            RelProfilesFeatures = new HashSet<RelProfilesFeatures>();
            RelUserProfiles = new HashSet<RelUserProfiles>();
        }
        [Key]
        public string ProId { get; set; }
        [Required]
        public string ProName { get; set; }

        public ICollection<RelProfilesFeatures> RelProfilesFeatures { get; set; }
        public ICollection<RelUserProfiles> RelUserProfiles { get; set; }
    }
}
