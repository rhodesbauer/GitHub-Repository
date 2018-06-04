using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntProfiles
    {
        public EntProfiles()
        {
            RelProfilesFeatures = new HashSet<RelProfilesFeatures>();
            RelUserProfiles = new HashSet<RelUserProfiles>();
        }

        public string ProId { get; set; }
        public string ProName { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<RelProfilesFeatures> RelProfilesFeatures { get; set; }
        public ICollection<RelUserProfiles> RelUserProfiles { get; set; }
    }
}
