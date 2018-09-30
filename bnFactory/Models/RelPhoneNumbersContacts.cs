using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelPhoneNumbersContacts : BasicModel
    {
        [ForeignKey("Pn")]
        public string PnId { get; set; }
        [ForeignKey("Con")]
        public string ConId { get; set; }

        public EntContacts Con { get; set; }
        public EntPhoneNumbers Pn { get; set; }
    }
}
