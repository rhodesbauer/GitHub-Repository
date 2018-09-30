using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Factory.Models
{
    public partial class RelBillGrouping : BasicModel
    {
        [ForeignKey("Bgr")]
        public string BgrId { get; set; }
        [ForeignKey("Bil")]
        public string BilId { get; set; }

        public EntBillGroup Bgr { get; set; }
        public EntBill Bil { get; set; }
    }
}
