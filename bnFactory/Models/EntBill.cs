using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntBill : BasicModel
    {
        public EntBill()
        {
            EntBillDetails = new HashSet<EntBillDetails>();
            RelBillGrouping = new HashSet<RelBillGrouping>();
            RelCategoryBill = new HashSet<RelCategoryBill>();
        }

        [Key]
        public string BilId { get; set; }
        public int BilCode { get; }
        [Required]
        public decimal? BilValue { get; set; }
        [Required]
        public decimal? BilMultiplicator { get; set; }
        [ForeignKey("Con")]
        public string ConId { get; set; }
        [Required]
        public DateTime? BilDateExpiration { get; set; }
        public DateTime? BilDateOfWarning { get; set; }
        public int? BilRecurrence { get; set; }
        [ForeignKey("Sta")]
        public string StaId { get; set; }
        [ForeignKey("Acc")]
        public string AccId { get; set; }

        public EntAccounts Acc { get; set; }
        public EntContacts Con { get; set; }
        public EntStatus Sta { get; set; }
        public ICollection<EntBillDetails> EntBillDetails { get; set; }
        public ICollection<RelBillGrouping> RelBillGrouping { get; set; }
        public ICollection<RelCategoryBill> RelCategoryBill { get; set; }
    }
}
