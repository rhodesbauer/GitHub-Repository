using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntAccountDetails : BasicModel
    {
        [Key]
        public string AdtId { get; set; }
        [ForeignKey("Acc")]
        public string AccId { get; set; }
        [MaxLength(50)]
        public string AdtAgency { get; set; }
        [MaxLength(50)]
        public string AdtAccount { get; set; }
        [MaxLength(50)]
        public string AdtAdditionalInformation { get; set; }

        public EntAccounts Acc { get; set; }

        public EntAccountDetails(string userID) : base(userID) {}
        
        public EntAccountDetails() {}
    }
}
