using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelUserContact
    {
        public string UserIdlastChange { get; set; }
        public string UserId { get; set; }
        public string ConId { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }
        public string UserIdcreation { get; set; }

        public EntContacts Con { get; set; }
        public EntUsers User { get; set; }
    }
}
