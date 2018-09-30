using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntBillGroup : BasicModel
    {
        public EntBillGroup()
        {
            RelBillGrouping = new HashSet<RelBillGrouping>();
        }

        [Key]
        public string BgrId { get; set; }
        [Required]
        public int BgrTotalInstallments { get; set; }
        [Required]
        public DateTime BgrDateOfFirstInstallment { get; set; }
        [Required]
        public DateTime BgrDateOfFinalInstallment { get; set; }

        public ICollection<RelBillGrouping> RelBillGrouping { get; set; }
    }
}
