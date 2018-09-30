using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntAccounts : BasicModel
    {
        public EntAccounts()
        {
            EntAccountDetails = new HashSet<EntAccountDetails>();
            EntBill = new HashSet<EntBill>();
            EntQuickEntry = new HashSet<EntQuickEntry>();
        }
        [Key]
        public string AccId { get; set; }
        [MaxLength(50)]
        public string AccName { get; set; }
        public int AccCode { get; }
        [ForeignKey("Typ")]
        public string TypId { get; set; }

        public EntTypes Typ { get; set; }
        public ICollection<EntAccountDetails> EntAccountDetails { get; set; }
        public ICollection<EntBill> EntBill { get; set; }
        public ICollection<EntQuickEntry> EntQuickEntry { get; set; }
    }
}
