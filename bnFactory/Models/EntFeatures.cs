using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntFeatures
    {
        public EntFeatures()
        {
            RelProfilesFeatures = new HashSet<RelProfilesFeatures>();
        }

        public string FeaId { get; set; }
        public string FeaName { get; set; }
        public string FeaParent { get; set; }
        public string FeaController { get; set; }
        public bool ShouldShow { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public ICollection<RelProfilesFeatures> RelProfilesFeatures { get; set; }
    }
}
