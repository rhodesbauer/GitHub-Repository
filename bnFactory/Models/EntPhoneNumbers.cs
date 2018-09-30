using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models
{
    public partial class EntPhoneNumbers : BasicModel
    {
        public EntPhoneNumbers()
        {
            RelPhoneNumbersContacts = new HashSet<RelPhoneNumbersContacts>();
        }
[Key]
        public string PnId { get; set; }
        public string PnType { get; set; }
        [Required]
        public string PnNumber { get; set; }
        [Required]
        public string PnName { get; set; }

        public ICollection<RelPhoneNumbersContacts> RelPhoneNumbersContacts { get; set; }
    }
}
