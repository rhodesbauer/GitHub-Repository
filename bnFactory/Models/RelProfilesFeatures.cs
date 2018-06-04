using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelProfilesFeatures
    {
        public string ProId { get; set; }
        public string FeaId { get; set; }
        public int Permission { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntFeatures Fea { get; set; }
        public EntProfiles Pro { get; set; }
    }
}
