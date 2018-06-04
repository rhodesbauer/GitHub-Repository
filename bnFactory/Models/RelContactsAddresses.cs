using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class RelContactsAddresses
    {
        public string UserIdcreation { get; set; }
        public string ConId { get; set; }
        public string AddId { get; set; }
        public string UserIdlastChange { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime? DtLastChange { get; set; }

        public EntAddresses Add { get; set; }
        public EntContacts Con { get; set; }
    }
}
