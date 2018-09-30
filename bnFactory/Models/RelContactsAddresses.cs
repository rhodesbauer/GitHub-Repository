using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelContactsAddresses : BasicModel
    {
        [ForeignKey("Con")]
        public string ConId { get; set; }
        [ForeignKey("Add")]
        public string AddId { get; set; }

        public EntAddresses Add { get; set; }
        public EntContacts Con { get; set; }
    }
}
