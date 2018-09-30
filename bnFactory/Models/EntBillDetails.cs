using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntBillDetails : BasicModel
    {
        [Key]
        public string BdtId { get; set; }
        [ForeignKey("Bil")]
        public string BilId { get; set; }
        [Required]
        public decimal BdtTotalValue { get; set; }
        public decimal? BdtDiscount { get; set; }
        public decimal? BdtInterest { get; set; }
        public decimal? BdtFine { get; set; }
        [Required]
        public DateTime BdtDateOfRegistration { get; set; }
        public string BtdObservation { get; set; }

        public EntBill Bil { get; set; }
    }
}
