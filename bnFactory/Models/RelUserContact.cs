using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelUserContact : BasicModel
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Con")]
        public string ConId { get; set; }

        public EntContacts Con { get; set; }
        public EntUsers User { get; set; }
    }
}
