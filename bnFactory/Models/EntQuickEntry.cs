using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntQuickEntry : BasicModel
    {
        [Key]
        public string QenId { get; set; }
        public string QenGroupId { get; set; }
        public int QenCode { get; }
        [ForeignKey("Cat")]
        public string CatId { get; set; }
        [ForeignKey("Acc")]
        public string AccId { get; set; }
        [Required]
        public decimal QenValue { get; set; }
        [Required]
        public DateTime QenDateActivation { get; set; }
        public int? QenInstallmentNumber { get; set; }
        public int? QenTotalInstallments { get; set; }

        public EntAccounts Acc { get; set; }
        public EntCategories Cat { get; set; }
    }
}
