using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntUsers
    {
        public EntUsers()
        {
            RelUserContact = new HashSet<RelUserContact>();
            RelUserProfiles = new HashSet<RelUserProfiles>();
        }

        public string UserIdlastChange { get; set; }
        public string UserId { get; set; }
        public int UserCode { get; set; }
        public string UserName { get; set; }
        public string UserKey { get; set; }
        public bool IsActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }

        public ICollection<RelUserContact> RelUserContact { get; set; }
        public ICollection<RelUserProfiles> RelUserProfiles { get; set; }
    }
}
