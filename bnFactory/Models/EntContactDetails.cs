using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class EntContactDetails : BasicModel
    {
        [Key]
        public string CdeId { get; set; }
        [ForeignKey("Con")]
        public string ConId { get; set; }
        [Required]
        public string CdeEmail { get; set; }

        public EntContacts Con { get; set; }
    }
}
