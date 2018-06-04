using System;
using System.Collections.Generic;

namespace Factory.Models
{
    public partial class EntAccountDetails : BasicModel
    {
        public string AdtId { get; set; }
        public string AccId { get; set; }
        public string AdtAgency { get; set; }
        public string AdtAccount { get; set; }
        public string AdtAdditionalInformation { get; set; }

        public EntAccounts Acc { get; set; }

        public EntAccountDetails(string userID) : base(userID) {}
    }
}
