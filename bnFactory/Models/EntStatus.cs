using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntStatus : BasicModel
    {
        public EntStatus()
        {
            EntBill = new HashSet<EntBill>();
        }
        [Key]
        public string StaId { get; set; }
        public int StaCode { get; }
        [Required]
        [MaxLength(50)]
        public string StaName { get; set; }
        [Required]
        public string StaDescription { get; set; }

        public ICollection<EntBill> EntBill { get; set; }
    }
}
