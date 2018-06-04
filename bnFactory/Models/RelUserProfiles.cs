using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelUserProfiles
    {
        public string UserId { get; set; }
        public string ProId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }
        public string UserIdlastChange { get; set; }

        public EntProfiles Pro { get; set; }
        public EntUsers User { get; set; }
    }
}
